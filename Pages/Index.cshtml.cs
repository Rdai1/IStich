using IStichIt.Models;
using IStichIt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IStichIt.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _context;
        public GetServices Service;
        public IEnumerable<Models.Services> ServicesList { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, AppDbContext context, GetServices serv)
        {
            _logger = logger;
            _context = context;
            Service = serv;
        }

        public void OnGet()
        {
            ServicesList = _context.Services.ToList();
        }
    }
}
