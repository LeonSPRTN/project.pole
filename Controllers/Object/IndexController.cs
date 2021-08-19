using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using project.pole.Data;

namespace project.pole.Controllers.Object
{
    /// <summary>
    /// Object Index controller
    /// </summary>
    [Authorize]
    [Route("object", Name = "object_route")]
    public class IndexController : Controller
    {
        private readonly ILogger<IndexController> _logger;
        private readonly ApplicationContext _context;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public IndexController(ILogger<IndexController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        /// <summary>
        /// Action index
        /// </summary>
        /// <returns>View</returns>
        public async Task<IActionResult> Action()
        {
            var objects = await _context.Objects.ToListAsync();
            
            return View("~/Views/Object/Index.cshtml", objects);
        }
    }
}