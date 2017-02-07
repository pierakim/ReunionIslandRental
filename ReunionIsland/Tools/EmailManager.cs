using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace ReunionIsland.Web.Tools
{
    public class EmailManager
    {
        public static bool SendMail(ContactEmail mail)
        {
            var smtp = new SmtpClient();
            var fromAddress = new MailAddress("pierakim.webdev@gmail.com", "Pierakim");//to conf
            const string fromPassword = "webdev**01";//to conf

            var mailer = new SmtpClient
            {
                Host = "smtp.gmail.com",//to conf
                Port = 587,//to conf
                EnableSsl = true,//to conf
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            string body;
            //Read template
            var path = HttpContext.Current.Server.MapPath("~/EmailTemplate/EmailTemplate.html");
            using (var sr = new StreamReader(path))
             {
                body = sr.ReadToEnd();
            }

            var messageBody = string.Format(body, mail.ContactName);

            var mailMessage = new MailMessage
            {
                From = fromAddress,
                Subject = "You contacted us!",
                Body = messageBody,
                IsBodyHtml = true
            };
            mailMessage.To.Add(new MailAddress(mail.To));
            mailer.Send(mailMessage);
            return true;
        }
    }

    public class ContactEmail
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
        public string DisplayName { get; set; }
        public string From { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactDescription { get; set; }

    }
}