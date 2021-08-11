using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using project.pole.Data;
using project.pole.Models;

namespace project.pole.Controllers
{
    public class ObjectController : Controller
    {
        private readonly ILogger<EstimateController> _logger;
        private readonly ApplicationContext _context;
        public ObjectController(ILogger<EstimateController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        [Authorize]
        [Route("object", Name = "object_route")]
        public IActionResult List()
        {
            var objects = _context.Objects;
            
            return View(objects);
        }
        
        [Authorize]
        [Route("object/show/{id}", Name = "object_show_route")]
        public async Task<IActionResult> Show(long id)
        {
            var obj = await _context.Objects.Where(x=>x.Id == id).FirstAsync();
            
            return View(obj);
        }
    }
}