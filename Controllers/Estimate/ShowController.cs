using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.pole.Services.Base;

namespace project.pole.Controllers.Estimate
{
    /// <summary>
    /// Estimate Show controller
    /// </summary>
    [Authorize]
    [Route("estimate/show/{id}", Name = "estimate_show_route")]
    public class ShowController : Controller
    {
        private readonly IEstimateService _estimateService;
        public ShowController(IEstimateService estimateService)
        {
            _estimateService = estimateService;
        }
        /// <summary>
        /// Action show
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public IActionResult Action(long id)
        {
            _estimateService.Generate();
            return RedirectToRoute("estimate_route");
        }
    }
}