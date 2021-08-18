using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data;

namespace project.pole.Controllers.Object
{
    /// <summary>
    /// Object Delete controller
    /// </summary>
    [Authorize]
    [Route("object/delete/{id}", Name = "object_delete_route")]
    public class DeleteController : Controller
    {
        private readonly ILogger<EstimateController> _logger;
        private readonly ApplicationContext _context;

        public DeleteController(ILogger<EstimateController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Action delete
        /// </summary>
        /// <returns>View</returns>
        public async Task<IActionResult> Action(long id)
        {
            var objects = _context.Objects;

            if (id > 0)
            {
                var obj = await objects.FindAsync(id);

                if (obj != null) objects.Remove(obj);
            }

            return View("~/Views/Object/Show.cshtml");
        }
    }
}