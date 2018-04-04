using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PersonalPhotoGallery.Controllers
{
    public class LoginsController : Controller
    {
        private readonly ILogins _loginsService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginsController(ILogins loginsService, IHttpContextAccessor httpContextAccessor)
        {
            _loginsService = loginsService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid login details");
                return View(model);
            }

            var user = await _loginsService.GetUser(model.Email);

            if (user != null)
            {
                if (user.Password == model.Password)
                {
                    _httpContextAccessor.HttpContext.Session.SetString("User", model.Email);
                }
                else
                {
                    ModelState.AddModelError("", "Login information is incorrect");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "User was not found");
                return View(model);
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid user details");
                return View(model);
            }

            var existingUser = await _loginsService.GetUser(model.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError("", "This email addres is allready registered");
                return View(model);
            }

            await _loginsService.CreateUser(model.Email, model.Password);
            return View();
        }
    }
}