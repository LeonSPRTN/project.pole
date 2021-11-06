using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data;
using project.pole.Data.Base;

namespace project.pole.Controllers.Customer
{
    /// <summary>
    /// Object Index controller
    /// </summary>
    [Authorize]
    [Route("customer", Name = "customer_route")]
    public class IndexController : Controller
    {
        private readonly ILogger<IndexController> _logger;
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="unitOfWork">customer repository</param>
        public IndexController(ILogger<IndexController> logger, UnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        
        /// <summary>
        /// Action index
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Action()
        {
            IList<Models.Customer> customer;
            using (_unitOfWork)
            {
                customer = _unitOfWork.Customer.FindAll();
            }

            return View("~/Views/Customer/Index.cshtml", customer);
        }
    }
}