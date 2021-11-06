using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data;
using project.pole.Data.Base;

namespace project.pole.Controllers.Customer
{
    /// <summary>
    /// Object Create Controller 
    /// </summary>
    [Authorize]
    [Route("customer/create", Name = "customer_create_route")]
    public class CreateController : Controller
    {
        private readonly ILogger<CreateController> _logger;
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="unitOfWork"></param>
        public CreateController(ILogger<CreateController> logger, UnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        
        /// <summary>
        /// Shows create Customer
        /// </summary>
        /// <returns>View("~/Views/ObjectWork/Create.cshtml")</returns>
        [HttpGet]
        public IActionResult ShowCreate()
        {
            return View("~/Views/Customer/Create.cshtml");
        }

        /// <summary>
        /// Creates customer to database
        /// </summary>
        /// <param name="customer">customer</param>
        /// <returns>RedirectToRoute("customer_route")</returns>
        [HttpPost]
        public IActionResult Create(Models.Customer customer)
        {
            using (_unitOfWork)
            {
                _unitOfWork.Customer.Create(customer);
                _unitOfWork.Save();
            }

            return RedirectToRoute("customer_route");
        }
    }
}