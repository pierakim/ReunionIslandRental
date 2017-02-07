using System.ComponentModel.DataAnnotations;

namespace ReunionIsland.Model
{
    public class ContactViewModel
    {
        public ContactViewModel()
        {
        }

        [Display(Name = "ContactName")]
        [Required(ErrorMessage = "A Contact name is required.")]
        [MaxLength(50, ErrorMessage = "Contact name can not be longer than 50 characters.")]
        public string ContactName { get; set; }

        [Display(Name = "eMail Address")]
        [Required(ErrorMessage = "An email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ContactEmail { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "A phone number is required.")]
        [MaxLength(10, ErrorMessage = "The phone number can not be longer than 10 characters")]
        public string ContactPhoneNumber { get; set; }

        [Display(Name = "Describe your project")]
        [Required(ErrorMessage = "A quick description of your project is required.")]
        [MaxLength(500, ErrorMessage = "The description can not be longer than 500 characters")]
        public string ContactDescription { get; set; }
    }
}
