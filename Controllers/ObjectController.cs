using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace project.pole.Controllers
{
    public class ObjectController : Controller
    {
        [Authorize]
        [Route("object", Name = "object_route")]
        public IActionResult Index()
        {
            return View();
        }
    }
}