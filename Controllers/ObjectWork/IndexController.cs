using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data;

namespace project.pole.Controllers.ObjectWork
{
    /// <summary>
    /// Object work Index controller
    /// </summary>
    public class IndexController: Controller
    {
        private readonly ILogger<IndexController> _logger;
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public IndexController(ILogger<IndexController> logger, UnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Action index
        /// </summary>
        /// <returns>View</returns>
        [Authorize]
        [Route("customer/{customerId:long}/object-work", Name = "customer_object_work_route")]
        public ActionResult Action(long customerId)
        {
            IList<Models.ObjectWork> objectWorks;
            using (_unitOfWork)
            {
                objectWorks = _unitOfWork.ObjectWork.FindAll(customerId);
            }

            return View("~/Views/ObjectWork/Index.cshtml", objectWorks);
        }

        /// <summary>
        /// Action index
        /// </summary>
        /// <returns>View</returns>
        [Authorize]
        [Route("object-work", Name = "object_work_route")]
        public ActionResult Action()
        {
            IList<Models.ObjectWork> objectWorks;
            using (_unitOfWork)
            {
                objectWorks = _unitOfWork.ObjectWork.FindAll();
            }

            return View("~/Views/ObjectWork/Index.cshtml", objectWorks);
        }
    }
}