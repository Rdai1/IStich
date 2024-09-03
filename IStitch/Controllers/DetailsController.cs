using IStitch.Interface;
using IStitch.Models;
using IStitch.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace IStitch.Controllers
{
    public class DetailsController : Controller
    {
        private readonly ILogger<DetailsController> _logger;
        private readonly AppDbContext _context;
        private readonly IServiceRepository _serviceRepository;
        public IEnumerable<Service> ServicesList { get; private set; }

        public DetailsController(ILogger<DetailsController> logger, IServiceRepository serviceRepository, AppDbContext context)
        {
            _logger = logger;
            _context = context;
            _serviceRepository = serviceRepository;
        }

        public async Task<IActionResult> Index(string id)
        {

            //ServicesList = _context.Service.Where(S => S.Category == id).ToList();

            IEnumerable<Service> serviceList = await _serviceRepository.GetAllWithCategory(id);

            //foreach (var service in ServicesList)
            //{
            //    _logger.LogInformation("Get Services: " + service.Name);
            //}

            ViewData["Category"] = id;

            return View(serviceList);
        }
    }
}
