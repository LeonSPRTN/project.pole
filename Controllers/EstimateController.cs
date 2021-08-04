using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace project.pole.Controllers
{
    public class EstimateController : Controller
    {
        private readonly ILogger<EstimateController> _logger;

        public EstimateController(ILogger<EstimateController> logger)
        {
            _logger = logger;
        }
        
        [Authorize]
        [Route("estimate", Name = "estimate_route")]
        public IActionResult Index()
        {
            return View();
        }
    }
}