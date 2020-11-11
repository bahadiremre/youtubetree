using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BESProject.YoutubeVideoTree.Web.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using BESProject.YoutubeVideoTree.Business.Interfaces;
using BESProject.YoutubeVideoTree.Entities.Concrete;

namespace BESProject.YoutubeVideoTree.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View(new UserLogInViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (CheckUserLogin(model))
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, model.UserName)
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Panel");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                }                
            }
            return View();
        }

        private bool CheckUserLogin(UserLogInViewModel model)
        {
            return userService.CheckUserLogin(model.UserName, model.Password);
        }

        public IActionResult SignUp()
        {
            return View(new UserSignUpViewModel());
        }

        [HttpPost]
        public IActionResult SignUp(UserSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { 
                    Email=model.Email,
                    Name=model.Name,
                    Password=model.Password,
                    Surname=model.Surname,
                    UserName=model.UserName
                };

                userService.SignUp(user);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
