using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data;

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
        private readonly ApplicationContext _context;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public CreateController(ILogger<CreateController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        /// <summary>
        /// Action create
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Action()
        {
            return View("~/Views/Сustomer/Create.cshtml");
        }
        
        [HttpPost("~/customer/create")]
        public async Task<IActionResult> Create(Models.Customer obj)
        {
            await _context.Customers.AddAsync(obj);
            await _context.SaveChangesAsync();
            
            return RedirectToRoute("object_route");
        }
    }
}