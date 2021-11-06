using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data;

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
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="unitOfWork">customer repository</param>
        public DeleteController(ILogger<DeleteController> logger, UnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Action delete
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Action(long id)
        {
            if (id > 0)
            {
                using (_unitOfWork)
                {
                    _unitOfWork.Customer.Remove(id);
                    _unitOfWork.Save();
                }
            }

            return RedirectToRoute("customer_route");
        }
    }
}