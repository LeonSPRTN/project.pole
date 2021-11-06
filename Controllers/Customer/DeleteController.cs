using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data.Base;

namespace project.pole.Controllers.Customer
{
    /// <summary>
    /// Object Delete controller
    /// </summary>
    [Authorize]
    [Route("customer/delete/{id:long}", Name = "customer_delete_route")]
    public class DeleteController : Controller
    {
        private readonly ILogger<DeleteController> _logger;
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="customerRepository">customer repository</param>
        public DeleteController(ILogger<DeleteController> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Action delete
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Action(long id)
        {
            if (id > 0)
            {
                _customerRepository.Remove(id);

            }
            return RedirectToRoute("customer_route");
        }
    }
}