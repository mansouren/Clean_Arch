using CleanArch.Application.Interfaces;
using CleanArch.Application.Security;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CleanArch.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Register()
        {
            return View();
        }

        #region Register
        [HttpPost]
        [Route("Account/Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid) return View(register);
            else
            {
                Check checkUser = userService.CheckUserEmailAndUserNameExist(register.Email, register.Username);
                if (checkUser != Check.Ok)
                {
                    ViewBag.check = checkUser;
                    return View(register);
                }
                User user = new User
                {
                    Username = register.Username,
                    Email = register.Email,
                    Password = PasswordHelper.EncodePasswordMd5(register.Password)
                };
                userService.RegisterUser(user);
                return View("SuccessRegister", register);
            }
        }

        [Route("Account/SuccessRegister")]
        public IActionResult SuccessRegister()
        {
            return View();
        }
        #endregion

        #region Login

        [HttpGet("Login")]
        public IActionResult Login(string ReturnUrl="/")
        {
            ViewBag.Return = ReturnUrl;
            return View();
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginViewModel viewModel, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            if (!userService.IsExistUser(viewModel.Email, viewModel.Password))
            {
                ModelState.AddModelError("Email", "User Not Found...!");
                return View(viewModel);
            }
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,viewModel.Email)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            var properties = new AuthenticationProperties
            {
                IsPersistent = viewModel.RemeberMe
            };

            HttpContext.SignInAsync(claimsPrincipal,properties);
            return Redirect(ReturnUrl);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
        #endregion
    }
}
