using System.ComponentModel.DataAnnotations;

namespace IStitch.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name required")]
        public string fName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name required")]
        public string lName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name= "Confirm Password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

    }
}
