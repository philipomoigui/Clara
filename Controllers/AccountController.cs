using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Clara.Extension_Methods;
using Clara.Models;
using Clara.Repository.Interface;
using Clara.Utility;
using Clara.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace Clara.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IRepositoryManager repositoryManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repositoryManager = repositoryManager;
            _emailSender = emailSender;
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
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

                    var conformationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);

                    await _emailSender.sendEmailAsync(model.Email, "Confirm Your Email", $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(conformationLink)}'> Clicking Here </a>");
                    
                    await AddIdentityToUserProfile(model, model.Email);

                    return RedirectToAction("Success", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if(userId == null && token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if(user == null)
            {
                ViewBag.ErrorMessage = "The user cannot be found";
                return View("Notfound");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                ViewBag.RegSuccess = "Email Succesfully Confirmed";
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Account", "User");
            }

            ViewBag.ErrorMessage = "The email could not be confirmed";
            return View("Notfound");
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
                var user = await _userManager.FindByEmailAsync(model.Email);

                if(user != null && !user.EmailConfirmed && (await _userManager.CheckPasswordAsync(user, model.Password)))
                {
                    ModelState.AddModelError("", "Email is not Confirmed");
                    return View(model);
                }

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

        public IActionResult Success()
        {
            return View();
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
                FirstName = model.FirstName.Capitalize(),
                LastName = model.LastName.Capitalize(),
                Email = model.Email,
                UserId = userId,
                PasswordChangeDate = model.PasswordChangeDate
            };

            _repositoryManager.UserProfile.AddUserProfile(userProfile);
            await _repositoryManager.saveAsync();
        }

    }

}
