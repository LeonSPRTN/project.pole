using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data.Base;
using project.pole.Services;

namespace project.pole.Controllers.Estimate
{
    /// <summary>
    /// Estimate Create controller
    /// </summary>
    [Authorize]
    [Route("object-work/{objectWorkId:long}/estimate/download", Name = "object_work_estimate_download_route")]
    public class CreateController: Controller
    {
        private readonly ILogger<CreateController> _logger;
        private readonly IEstimateService _estimateService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="estimateService">Estimate service</param>
        public CreateController(ILogger<CreateController> logger, IEstimateService estimateService)
        {
            _logger = logger;
            _estimateService = estimateService;
        }

        /// <summary>
        /// Action create
        /// </summary>
        /// <param name="objectWorkId"></param>
        /// <returns>FileResult</returns>
        public FileResult Action(long objectWorkId)
        {
            var estimateFile = _estimateService.Generate(objectWorkId);

            return File(estimateFile, "application/pdf", "Смета.pdf");
        }
    }
}