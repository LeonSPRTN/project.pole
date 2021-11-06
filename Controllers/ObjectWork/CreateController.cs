using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data;

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
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="objectWorkRepository">customer repository</param>
        public CreateController(ILogger<CreateController> logger, UnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
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
            using (_unitOfWork)
            {
                _unitOfWork.ObjectWork.Create(objectWork);
                _unitOfWork.Save();
            }

            return RedirectToRoute("customer_route");
        }
    }
}