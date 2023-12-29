using IStichIt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IStichIt.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger;
        private readonly AppDbContext _context;
        public IEnumerable<Service> ServicesList { get; private set; }

        public DetailsModel(ILogger<DetailsModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet(string key)
        {
            ServicesList = _context.Service.Where(S => S.Category == key).ToList();


            foreach (var service in ServicesList)
            {
                _logger.LogInformation("Get Services: " + service.Name);
            }
        }
    }
}
