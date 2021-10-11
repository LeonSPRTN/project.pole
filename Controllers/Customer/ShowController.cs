using System.Threading.Tasks;
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
        private readonly ApplicationContext _context;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public ShowController(ILogger<ShowController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Action show
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public async Task<IActionResult> Action(long id)
        {
            var obj = await _context.Customers.FindAsync(id);

            return View("~/Views/Сustomer/Show.cshtml", obj);
        }
    }
}