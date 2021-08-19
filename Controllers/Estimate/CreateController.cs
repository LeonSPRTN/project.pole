using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace project.pole.Controllers.Estimate
{
    /// <summary>
    /// Estimate Create controller
    /// </summary>
    [Authorize]
    [Route("estimate/create/{id}", Name = "estimate_show_route")]
    public class CreateController: Controller
    {
        /// <summary>
        /// Action create
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public IActionResult Action(long id)
        {
            return RedirectToRoute("estimate_route");
        }
    }
}