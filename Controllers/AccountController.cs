using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clara.Models;
using Clara.Repository.Interface;
using Clara.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Clara.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IRepositoryManager _repositoryManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IRepositoryManager repositoryManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repositoryManager = repositoryManager;
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    await AddIdentityToUserProfile(model, model.Email);

                    return RedirectToAction("Account", "User");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
               var result =  await  _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Account", "User");
                }

                ModelState.AddModelError("", "Invalid Email or Password");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task AddIdentityToUserProfile(RegisterViewModel model, string email)
        {
            var user = _userManager.FindByEmailAsync(email);
            var userId = user.Result.Id;

            UserProfile userProfile = new UserProfile
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserId = userId
            };

            _repositoryManager.UserProfile.AddUserProfile(userProfile);
            await _repositoryManager.saveAsync();
        }

    }

}
