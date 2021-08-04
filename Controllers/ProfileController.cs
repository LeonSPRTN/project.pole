﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace project.pole.Controllers
{
    public class ProfileController: Controller
    {
        private readonly ILogger<ProfileController> _logger;
        
        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        [Route("profile", Name = "profile_route")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
