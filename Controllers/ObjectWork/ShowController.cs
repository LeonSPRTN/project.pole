using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data.Base;

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
            private readonly IObjectWorkRepository _objectWorkRepository;

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="logger"></param>
            /// <param name="objectWorkRepository"></param>
            public IndexController(ILogger<IndexController> logger, IObjectWorkRepository objectWorkRepository)
            {
                _logger = logger;
                _objectWorkRepository = objectWorkRepository;
            }

            /// <summary>
            /// Action index
            /// </summary>
            /// <returns>View</returns>
            public ActionResult Action()
            {
                var objectWork = _objectWorkRepository.FindAll();

                return View("~/Views/ObjectWork/Show.cshtml", objectWork);
            }
        }
    }
}