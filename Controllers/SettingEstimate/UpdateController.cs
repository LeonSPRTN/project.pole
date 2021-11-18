using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data.Base;

namespace project.pole.Controllers.SettingEstimate
{
    /// <summary>
    /// Setting estimate Update controller
    /// </summary>
    [Authorize]
    [Route("setting-estimate", Name = "setting_estimate_route")]
    public class UpdateController: Controller
    {
        private readonly ILogger<UpdateController> _logger;
        private readonly ISettingEstimateRepository _settingEstimateRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="settingEstimateRepository">customer repository</param>
        public UpdateController(ILogger<UpdateController> logger, ISettingEstimateRepository settingEstimateRepository)
        {
            _logger = logger;
            _settingEstimateRepository = settingEstimateRepository;
        }

        /// <summary>
        /// Action show
        /// </summary>
        /// <param name="settingEstimate"></param>
        /// <returns>View</returns>
        [HttpPost]
        public IActionResult Action(Models.SettingEstimate settingEstimate)
        {
            if (settingEstimate.Id == 0)
            {
                _settingEstimateRepository.Create(settingEstimate);
            }
            else
            {
                _settingEstimateRepository.Update(settingEstimate);
            }

            return View("~/Views/SettingEstimate/Index.cshtml", settingEstimate);
        }
    }
}