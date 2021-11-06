using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data;

namespace project.pole.Controllers.Customer
{
    /// <summary>
    /// Object Show controller
    /// </summary>
    [Authorize]
    [Route("customer/show/{id}", Name = "customer_show_route")]
    public class ShowController: Controller
    {
        private readonly ILogger<ShowController> _logger;
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="unitOfWork">customer repository</param>
        public ShowController(ILogger<ShowController> logger, UnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Action show
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public IActionResult Action(long id)
        {
            Models.Customer customer;
            using (_unitOfWork)
            {
                customer = _unitOfWork.Customer.Find(id);
            }
            
            return View("~/Views/Customer/Show.cshtml", customer);
        }
    }
}