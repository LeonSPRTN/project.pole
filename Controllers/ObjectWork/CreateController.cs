using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data.Base;

namespace project.pole.Controllers.ObjectWork
{
    /// <summary>
    /// Estimate Create controller
    /// </summary>
    [Authorize]
    [Route("object-work/create", Name = "object_work_create_route")]
    public class CreateController : Controller
    {
        private readonly ILogger<CreateController> _logger;
        private readonly IObjectWorkRepository _objectWorkRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="objectWorkRepository">customer repository</param>
        public CreateController(ILogger<CreateController> logger, IObjectWorkRepository objectWorkRepository)
        {
            _logger = logger;
            _objectWorkRepository = objectWorkRepository;
        }

        /// <summary>
        /// Shows create Customer
        /// </summary>
        /// <returns>View("~/Views/Customer/Create.cshtml")</returns>
        [HttpGet]
        public IActionResult Create(long customerId)
        {
            var objectWork = new Models.ObjectWork
            {
                CustomerId = customerId
            };
            return View("~/Views/ObjectWork/Create.cshtml", objectWork);
        }

        /// <summary>
        /// Creates customer to database
        /// </summary>
        /// <param name="objectWork"></param>
        /// <returns>RedirectToRoute("object_route")</returns>
        [HttpPost]
        public IActionResult Create(Models.ObjectWork objectWork)
        {
            _objectWorkRepository.Create(objectWork);

            return RedirectToRoute("customer_route");
        }
    }
}