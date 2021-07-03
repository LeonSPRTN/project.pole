using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.pole.Controllers
{
    public class PersonalAccountController: Controller
    {
        private readonly ILogger<PersonalAccountController> _logger;

        public PersonalAccountController(ILogger<PersonalAccountController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        [Route("PersonalAccount/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
