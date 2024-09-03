using IStitch.Models;
using IStitch.Data;
using IStitch.GetSer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using IStitch.Interface;
using IStitch.Repository;

namespace IStitch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly AppDbContext _context;
        private readonly IServiceTypeRepository _serviceTypeRepository;
        public GetServices Service;
        public IEnumerable<Models.ServiceType> ServicesList { get; private set; }

        public HomeController(ILogger<HomeController> logger, IServiceTypeRepository serviceTypeRepoository, AppDbContext context, GetServices serv)
        {
            _logger = logger;
            //_context = context;
            //Service = serv;
            _serviceTypeRepository = serviceTypeRepoository;
        }

        public async Task<IActionResult> Index()
        {
            //ServicesList = _context.ServiceType.ToList();
            IEnumerable<ServiceType> ServicesList = await _serviceTypeRepository.GetAll();
            return View(ServicesList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
