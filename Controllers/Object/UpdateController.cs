using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data;

namespace project.pole.Controllers.Object
{
    /// <summary>
    /// Object Update controller
    /// </summary>
    [Authorize]
    [Route("object/update/", Name = "object_update_route")]
    public class UpdateController : Controller
    {
        private readonly ILogger<EstimateController> _logger;
        private readonly ApplicationContext _context;
        public UpdateController(ILogger<EstimateController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        /// <summary>
        /// Action update
        /// </summary>
        /// <returns>View</returns>
        public async Task<IActionResult> Action(Models.Object obj)
        {
            _context.Objects.Update(obj);
            await _context.SaveChangesAsync();
                
            return RedirectToRoute("object_route");
        }
    }
}