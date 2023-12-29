using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IStichIt.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Subject { get; set; }

        [BindProperty]
        public string Message { get; set; }

        public void OnGet()
        {
            // This is executed when the page is loaded initially
        }

        public IActionResult OnPost()
        {
            // This is executed when the form is submitted
            // You can handle the form submission logic here, for example, sending an email

            // For demonstration purposes, let's just return to the home page
            return RedirectToPage("/Index");
        }
    }
}
