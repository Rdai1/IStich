using IStitch.Data;
using IStitch.GetSer;
using IStitch.Interface;
using IStitch.Models;
using IStitch.Repository;
using IStitch.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IStitch.Controllers
{
    public class ServiceOrderController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IServiceTypeRepository _serviceTypeRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICustomerItemRepository _customerItemRepository;

        public ServiceOrderController(ILogger<HomeController> logger, IServiceTypeRepository serviceTypeRepository,
            IServiceRepository serviceRepoository, IUserRepository userRepository,
            ICustomerItemRepository customerItemRepository, IHttpContextAccessor httpContextAccessor) 
        { 
            _logger = logger;
            _serviceTypeRepository = serviceTypeRepository;
            _serviceRepository = serviceRepoository;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _customerItemRepository = customerItemRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            //var curUserId = _httpContextAccessor.HttpContext.User.GetUserid();
            IEnumerable<ServiceType> serviceType = await _serviceTypeRepository.GetAll();
            CustomerItemViewModel customerItemViewModel = new CustomerItemViewModel
            {
                ServicesTypeCategoryList = serviceType,
                PickUpDate = DateTime.Today.AddDays(2)
            };
            return View(customerItemViewModel);
        }

        [HttpPost]
        //gets the services based of servicetype?
        public async Task<IActionResult> GetServicesByCategory(string Category)
        {
            _logger.LogInformation("ITS HERERERERR: " + Category);
            IEnumerable<Service> services = await _serviceRepository.GetAllWithCategory(Category);
            CustomerItemViewModel customerItemViewModel = new CustomerItemViewModel
            {
                ServiceNameList = services
            };
            return PartialView("_ServiceDropdownPartial", customerItemViewModel);
        }

        //creates the actual serviceOrder
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CustomerItemViewModel item)
        {
            var ser = await _serviceRepository.GetByName(item.SerName);
            var customer = await _userRepository.GetByPhoneNumber(item.PhoneNumber);
            CustomerItems customerItems = new CustomerItems()
            {
                SerName = item.SerName,
                Category = item.CategoryName,
                Service = ser,
                PickUpDate = item.PickUpDate,
                CustomerId = customer.Id,
                ItemDescription = item.ItemDescription
            };

            _customerItemRepository.Add(customerItems);

            return RedirectToAction("Create");
        }

        //get all services related to a customer
        public async Task<IActionResult> getServiceOrderByUser()
        {
            return View();
        }

        //update the list
        [HttpPost]
        public async Task<IActionResult> getCustomerServices(string phoneNumber)
        {
            var customer = await _userRepository.GetByPhoneNumber(phoneNumber);
            IEnumerable<CustomerItems> items = await _customerItemRepository.GetAllWithCustomerId(customer.Id);

            ViewData["CustomerName"] = customer.fName;

            return PartialView("_itemList", items);
        }
    }
}
