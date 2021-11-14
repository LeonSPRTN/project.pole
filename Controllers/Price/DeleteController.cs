using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data.Base;

namespace project.pole.Controllers.Price
{
    [Authorize]
    [Route("price/delete", Name = "price_delete_route")]
    public class DeleteController: Controller
    {
        private readonly ILogger<DeleteController> _logger;
        private readonly IPriceRepository _priceRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="priceRepository">object work repository</param>
        public DeleteController(ILogger<DeleteController> logger, IPriceRepository priceRepository)
        {
            _logger = logger;
            _priceRepository = priceRepository;
        }

        /// <summary>
        /// Action delete
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Action(long id)
        {
            if (id > 0)
            {
                _priceRepository.Remove(id);
            }
            
            return RedirectToRoute("price_route");
        }
    }
}