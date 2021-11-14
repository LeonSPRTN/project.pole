using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data.Base;
using project.pole.Models;

namespace project.pole.Controllers.Price
{
    /// <summary>
    /// Price Create controller
    /// </summary>
    [Authorize]
    [Route("price/create", Name = "price_create_route")]
    public class CreateController: Controller
    {
        private readonly ILogger<CreateController> _logger;
        private readonly IPriceRepository _priceRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="priceRepository">customer repository</param>
        public CreateController(ILogger<CreateController> logger, IPriceRepository priceRepository)
        {
            _logger = logger;
            _priceRepository = priceRepository;
        }

        /// <summary>
        /// Creates customer to database
        /// </summary>
        /// <param name="price"></param>
        /// <returns>RedirectToRoute("object_route")</returns>
        [HttpPost]
        public IActionResult Create(Models.Price price)
        {
            if (ModelState.IsValid)
            {
                _priceRepository.Create(price);
            }
            
            return RedirectToRoute("price_route");
        }
    }
}