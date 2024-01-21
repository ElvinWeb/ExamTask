﻿using Boocic.Business.CustomExceptions.User;
using Boocic.Business.Services;
using Boocic.Business.ViewModels;
using Boocic.Core.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Boocic.UI.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAccountService _accountService;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IAccountService accountService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _accountService = accountService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel adminLoginViewModel)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                await _accountService.Login(adminLoginViewModel);
            }
            catch (InvalidCredentials ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(" ", "Unexpected error is occur!");
                return View();
            }


            return RedirectToAction("index", "service");
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();

            return RedirectToAction("login", "account");
        }

        #region Admin Create, AddRole, CreateRole operations

        //public async Task<IActionResult> CreateAdmin()
        //{
        //    User admin = new User
        //    {
        //        Fullname = "Elvin Sarkarov",
        //        UserName = "Admin1",
        //    };

        //    var result = await _userManager.CreateAsync(admin, "@Admin1234");

        //    return Ok(result);
        //}

        //public async Task<IActionResult> CreateRoles()
        //{
        //    IdentityRole role1 = new IdentityRole("SuperAdmin");
        //    IdentityRole role2 = new IdentityRole("Admin");
        //    IdentityRole role3 = new IdentityRole("Member");

        //    await _roleManager.CreateAsync(role1);
        //    await _roleManager.CreateAsync(role2);
        //    await _roleManager.CreateAsync(role3);

        //    return Ok("rollar yarandi");
        //}

        //public async Task<IActionResult> AddRole()
        //{
        //    var admin = await _userManager.FindByNameAsync("Admin1");

        //    var result = await _userManager.AddToRoleAsync(admin, "SuperAdmin");

        //    return Ok("rol elave edildi!");
        //}
        #endregion
    }
}
