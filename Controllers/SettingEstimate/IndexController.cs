using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data.Base;

namespace project.pole.Controllers.SettingEstimate
{
    /// <summary>
    /// Setting estimate Index controller
    /// </summary>
    [Authorize]
    [Route("setting-estimate", Name = "setting_estimate_route")]
    public class IndexController: Controller
    {
        private readonly ILogger<IndexController> _logger;
        private readonly ISettingEstimateRepository _settingEstimateRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="settingEstimateRepository"></param>
        public IndexController(ILogger<IndexController> logger, ISettingEstimateRepository settingEstimateRepository)
        {
            _logger = logger;
            _settingEstimateRepository = settingEstimateRepository;
        }
        
        public ActionResult Action()
        {
            var settingEstimate = _settingEstimateRepository.Find();

            return View("~/Views/SettingEstimate/Index.cshtml", settingEstimate);
        }
    }
}