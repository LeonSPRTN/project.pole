using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data.Base;

namespace project.pole.Controllers.ObjectWork
{
    /// <summary>
    /// Object work Index controller
    /// </summary>
    public class IndexController: Controller
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
        [Authorize]
        [Route("customer/{customerId:long}/object-work", Name = "customer_object_work_route")]
        public ActionResult Action(long customerId)
        {
            var objectWorks = _objectWorkRepository.FindAll(customerId);

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
            var objectWorks = _objectWorkRepository.FindAll();

            return View("~/Views/ObjectWork/Index.cshtml", objectWorks);
        }
    }
}