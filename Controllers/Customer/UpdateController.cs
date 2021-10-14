using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data.Base;

namespace project.pole.Controllers.Customer
{
    /// <summary>
    /// Object Update controller
    /// </summary>
    [Authorize]
    [Route("customer/update/", Name = "customer_update_route")]
    public class UpdateController : Controller
    {
        private readonly ILogger<DeleteController> _logger;
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="customerRepository">customer repository</param>
        public UpdateController(ILogger<DeleteController> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Action update
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Action(Models.Customer customer)
        {
            _customerRepository.Update(customer);

            return RedirectToRoute("object_route");
        }
    }
}