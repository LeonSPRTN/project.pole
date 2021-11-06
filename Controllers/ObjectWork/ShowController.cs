using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data;

namespace project.pole.Controllers.ObjectWork
{
    public class ShowController : Controller
    {
        /// <summary>
        /// Object work Index controller
        /// </summary>
        [Authorize]
        [Route("customer/object-work/show", Name = "customer_object_work_show_route")]
        public class IndexController : Controller
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
            public ActionResult Action()
            {
                IList<Models.ObjectWork> objectWork;
                using (_unitOfWork)
                {
                    objectWork = _unitOfWork.ObjectWork.FindAll();
                }

                return View("~/Views/ObjectWork/Show.cshtml", objectWork);
            }
        }
    }
}