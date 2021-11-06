using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data;

namespace project.pole.Controllers.ObjectWork
{
    /// <summary>
    /// Object Delete controller
    /// </summary>
    public class DeleteController : Controller
    {
        private readonly ILogger<DeleteController> _logger;
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="unitOfWork"></param>
        public DeleteController(ILogger<DeleteController> logger, UnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
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
                using (_unitOfWork)
                {
                    _unitOfWork.ObjectWork.Remove(id);
                    _unitOfWork.Save();
                }
            }
            return RedirectToRoute("customer_object_work_route", new {customerId = customerId});
        }
    }
}