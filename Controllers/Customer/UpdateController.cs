using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data;
using project.pole.Data.Base;

namespace project.pole.Controllers.Customer
{
    /// <summary>
    /// Object Update controller
    /// </summary>
    [Authorize]
    [Route("customer/update", Name = "customer_update_route")]
    public class UpdateController : Controller
    {
        private readonly ILogger<UpdateController> _logger;
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="unitOfWork">customer repository</param>
        public UpdateController(ILogger<UpdateController> logger, UnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Action update
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Action(Models.Customer customer)
        {
            using (_unitOfWork)
            {
                _unitOfWork.Customer.Update(customer);
                _unitOfWork.Save();
            }

            return RedirectToRoute("customer_route");
        }
    }
}