﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.pole.Data;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace project.pole.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ApplicationContext _context;

        public LoginController(ILogger<LoginController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validate(string login, string password, string returnUrl)
        {
            await using (_context)
            {
                var result = _context.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefault();

                ViewData["ReturnUrl"] = returnUrl;
                if (result != null)
                {
                    List<Claim> claims = new();
                    claims.Add(new Claim("login", login));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, login));
                    ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    if (returnUrl != null)
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToRoute("profile_route");
                    }
                }
            }

            TempData["Error"] = "Ошибка. Неверный логин или пароль";
            return View("login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}