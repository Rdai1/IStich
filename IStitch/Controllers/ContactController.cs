using Microsoft.AspNetCore.Mvc;

namespace IStitch.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Form()
        {
            return View();
        }
    }
}
