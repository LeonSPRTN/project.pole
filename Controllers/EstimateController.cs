using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using project.pole.Data;

namespace project.pole.Controllers
{
    public class EstimateController : Controller
    {
        private readonly ILogger<EstimateController> _logger;
        private readonly ApplicationContext _context;

        public EstimateController(ILogger<EstimateController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        [Authorize]
        [Route("estimate", Name = "estimate_route")]
        public IActionResult List()
        {
            var estimates = _context.Estimates;
            
            return View(estimates);
        }
        
        [Authorize]
        [Route("estimate/show/{id}", Name = "estimate_show_route")]
        public IActionResult Show(long id)
        {
            return View();
        }
    }
}