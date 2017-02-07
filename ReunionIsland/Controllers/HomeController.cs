using System;
using System.Web.Mvc;
using ReunionIsland.Model;
using ReunionIsland.Web.Tools;

namespace ReunionIsland.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new ContactViewModel();
            //to test the modal pop up...
            //TempData["shortMessage"] = "Thank you for contacting me!";
            if (TempData["shortMessage"] != null)
            {
                ViewBag.ShowSuccessMessage = TempData["shortMessage"].ToString();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        ViewBag.ShowSuccessMessage = string.Empty;
                        var contactDetail = new ContactEmail
                        {
                            To = model.ContactEmail,
                            ContactName = model.ContactName,
                            ContactPhoneNumber = model.ContactPhoneNumber,
                            ContactDescription = model.ContactDescription
                        };

                        var result = EmailManager.SendMail(contactDetail);
                        TempData["shortMessage"] = result ? "Thank you for contacting me!" : "Arrf, something wrong happened.";

                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}