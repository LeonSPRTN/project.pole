using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data.Base;

namespace project.pole.Controllers.Customer
{
    /// <summary>
    /// Object Create Controller 
    /// </summary>
    [Authorize]
    [Route("customer/create", Name = "customer_create_route")]
    public class CreateController : Controller
    {
        private readonly ILogger<CreateController> _logger;
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="customerRepository">customer repository</param>
        public CreateController(ILogger<CreateController> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }
        
        /// <summary>
        /// Shows form create Customer
        /// </summary>
        /// <returns>View("~/Views/ObjectWork/Create.cshtml")</returns>
        [HttpGet]
        public IActionResult ShowCreate()
        {
            return View("~/Views/Customer/Create.cshtml");
        }

        /// <summary>
        /// Creates customer
        /// </summary>
        /// <param name="customer">customer</param>
        /// <returns>RedirectToRoute("customer_route")</returns>
        [HttpPost]
        public IActionResult Create(Models.Customer customer)
        {
            _customerRepository.Create(customer);

            return RedirectToRoute("customer_route");
        }
    }
}