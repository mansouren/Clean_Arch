using CleanArch.Application.Interfaces;
using CleanArch.Application.Security;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        [Route("Account/Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            if(!ModelState.IsValid) return View(register);
            else
            {
                Check checkUser = userService.CheckUserEmailAndUserNameExist(register.Email, register.Username);
                if(checkUser !=Check.Ok)
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
                return View("SuccessRegister",register);
            }
        }

        [Route("Account/SuccessRegister")]
        public IActionResult SuccessRegister()
        {
            return View();
        }
    }
}
