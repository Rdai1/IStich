using IStichIt.Models;
using IStichIt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IStichIt.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public GetServices Service;
        public IEnumerable<Models.Services> ServicesList { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, GetServices serv)
        {
            _logger = logger;
            Service = serv;
        }

        public void OnGet()
        {
            ServicesList = Service.GetServicesList();
        }
    }
}
