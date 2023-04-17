using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Video_Library.Areas.Admin.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Video_Library.Areas.Admin.Models;
using Video_Library.Models;
using Microsoft.AspNetCore.Authorization;

namespace Video_Library.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AccountController : Controller
    {
        private UserManager<IdentityCustomUser> UserManager;
        private SignInManager<IdentityCustomUser> SignInManager;
        private ApplicationDbContext context;
        public AccountController(UserManager<IdentityCustomUser> _userManager, SignInManager<IdentityCustomUser> _signInManager, ApplicationDbContext _context)
        {
            UserManager = _userManager;
            SignInManager = _signInManager;
            context = _context;
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                //success
                var user = context.Users.SingleOrDefault(e => e.UserName == model.Email);
                if (user != null)
                {
                    var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        RedirectToAction("Index", "Home", new { Areas = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Login Credentials!");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid User!");
                    return View();
                }
            }
                return View(model);
        }
        [Authorize]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityCustomUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    Email = model.Email,
                    PasswordHash = model.Password,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.Email
                };
                //success
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    ViewBag.message = "User is Created Successfully!";
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    foreach (var er in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, er.Description);
                    }
                    return View();
                }
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> SignOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login", new { Areas = "Admin" });
        }
    }
}
