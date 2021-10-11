using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data;

namespace project.pole.Controllers.Customer
{
    /// <summary>
    /// Object Update controller
    /// </summary>
    [Authorize]
    [Route("customer/update/", Name = "customer_update_route")]
    public class UpdateController : Controller
    {
        private readonly ILogger<UpdateController> _logger;
        private readonly ApplicationContext _context;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public UpdateController(ILogger<UpdateController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        /// <summary>
        /// Action update
        /// </summary>
        /// <returns>View</returns>
        public async Task<IActionResult> Action(Models.Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
                
            return RedirectToRoute("object_route");
        }
    }
}