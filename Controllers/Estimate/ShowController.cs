using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace project.pole.Controllers.Estimate
{
    /// <summary>
    /// Estimate Show controller
    /// </summary>
    [Authorize]
    [Route("estimate/show/{id}", Name = "estimate_show_route")]
    public class ShowController : Controller
    {
        /// <summary>
        /// Action show
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public IActionResult Action(long id)
        {
            return RedirectToRoute("estimate_route");
        }
    }
}