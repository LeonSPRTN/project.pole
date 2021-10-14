using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data.Base;

namespace project.pole.Controllers.Customer
{
    /// <summary>
    /// Object Show controller
    /// </summary>
    [Authorize]
    [Route("customer/show/{id}", Name = "customer_show_route")]
    public class ShowController: Controller
    {
        private readonly ILogger<DeleteController> _logger;
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="customerRepository">customer repository</param>
        public ShowController(ILogger<DeleteController> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Action show
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public IActionResult Action(long id)
        {
            var customer = _customerRepository.Find(id);

            return View("~/Views/Customer/Show.cshtml", customer);
        }
    }
}