using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data.Base;

namespace project.pole.Controllers.Price
{
    /// <summary>
    /// Price Index controller
    /// </summary>
    [Authorize]
    [Route("price", Name = "price_route")]
    public class IndexController: Controller
    {
        private readonly ILogger<IndexController> _logger;
        private readonly IPriceRepository _priceRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="priceRepository"></param>
        public IndexController(ILogger<IndexController> logger, IPriceRepository priceRepository)
        {
            _logger = logger;
            _priceRepository = priceRepository;
        }
        
        public ActionResult Action()
        {
            ViewBag.Prices = _priceRepository.FindAll();

            return View("~/Views/Price/Index.cshtml");
        }
    }
}