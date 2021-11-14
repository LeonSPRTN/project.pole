using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace project.pole.Controllers
{
    public class ProfileController: Controller
    {
        private readonly ILogger<ProfileController> _logger;
        
        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        [Route("profile", Name = "profile_route")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
