using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data.Base;

namespace project.pole.Controllers.ObjectWork
{
    /// <summary>
    /// Object Delete controller
    /// </summary>
    public class DeleteController : Controller
    {
        private readonly ILogger<DeleteController> _logger;
        private readonly IObjectWorkRepository _objectWorkRepository;
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="objectWorkRepository">object work repository</param>
        public DeleteController(ILogger<DeleteController> logger, IObjectWorkRepository objectWorkRepository, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _objectWorkRepository = objectWorkRepository;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Action delete
        /// </summary>
        /// <returns>View</returns>
        [Authorize]
        [Route("customer/{customerId:long}/object-work/{id:long}/delete", Name = "customer_object_work_delete_route")]
        public IActionResult Action(long id, long customerId)
        {
            if (id > 0 && customerId > 0)
            {
                _objectWorkRepository.Remove(id);
            }
            return RedirectToRoute("customer_object_work_route", new {customerId = customerId});
        }
    }
}