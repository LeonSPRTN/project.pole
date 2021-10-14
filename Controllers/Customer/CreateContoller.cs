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
        private readonly ILogger<DeleteController> _logger;
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="customerRepository">customer repository</param>
        public CreateController(ILogger<DeleteController> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }
        
        /// <summary>
        /// Shows create Customer
        /// </summary>
        /// <returns>View("~/Views/Customer/Create.cshtml")</returns>
        public IActionResult ShowCreate()
        {
            return View("~/Views/Customer/Create.cshtml");
        }

        /// <summary>
        /// Creates customer to database
        /// </summary>
        /// <param name="customer">customer</param>
        /// <returns>RedirectToRoute("object_route")</returns>
        [HttpPost("~/customer/create")]
        public IActionResult Create(Models.Customer customer)
        {
            _customerRepository.Create(customer);

            return RedirectToRoute("customer_route");
        }
    }
}