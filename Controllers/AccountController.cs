using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Clara.Extension_Methods;
using Clara.Infrastructure;
using Clara.Models;
using Clara.Repository.Interface;
using Clara.Utility;
using Clara.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Clara.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IEmailSender _emailSender;
        private readonly IHubContext<SignalServer> _hubRepository;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IRepositoryManager repositoryManager, IEmailSender emailSender, IHubContext<SignalServer> hubRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repositoryManager = repositoryManager;
            _emailSender = emailSender;
            _hubRepository = hubRepository;
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
            var tokenDecodeBytes = WebEncoders.Base64UrlDecode(token);
            var tokenDecode = Encoding.UTF8.GetString(tokenDecodeBytes);

            var result = await _userManager.ConfirmEmailAsync(user, tokenDecode);

            if (result.Succeeded)
            {
                ViewBag.RegSuccess = "Email Succesfully Confirmed";
                return RedirectToAction("Login", "Account");
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null && await _userManager.IsEmailConfirmedAsync(user))
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

                    var confirmationLink = Url.Action("ResetPassword", "Account", new {email = model.Email, token = encodedToken }, Request.Scheme);
                    await _emailSender.sendEmailAsync(model.Email, "Password Reset", $"Click <a href='{HtmlEncoder.Default.Encode(confirmationLink)}'> Here</a> to reset your password <br/> <br/> if you did not initiate this request, kindly ignore.");

                    return RedirectToAction("ForgotPasswordConfirmation", "Account");
                }
                return View("ForgotPasswordConfirmation");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            ResetPasswordViewModel model = new ResetPasswordViewModel
            {
                Email = email,
                Token = token
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var userprofile = _repositoryManager.UserProfile.GetUserProfile(user.Id);

                if(user != null && await _userManager.IsEmailConfirmedAsync(user))
                {
                    var tokenDecodeByte = WebEncoders.Base64UrlDecode(model.Token);
                    var tokenDecode = Encoding.UTF8.GetString(tokenDecodeByte);

                    var result = await _userManager.ResetPasswordAsync(user, tokenDecode, model.ConfirmPassword);

                    if (result.Succeeded)
                    {
                        var message = $"Hello {userprofile.FirstName}, <br/> <br/> This is to inform you that your password was just changed. <br/> <br/> if you did not initiate this change, please contact us at support@clara.com";
                        await _emailSender.sendEmailAsync(model.Email, "Password Changed", message);

                        SendNotificationToUser(user);

                        await _repositoryManager.saveAsync();

                        await _hubRepository.Clients.All.SendAsync("displayNotification", "");

                        return RedirectToAction("ResetPasswordConfirmation");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }

                    return View();
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        private void SendNotificationToUser(ApplicationUser user)
        {
            var notification = new Notification();
            notification.Text = "You just Reset your password";

            NotificationApplicationUser userNotification = new NotificationApplicationUser();
            userNotification.NotificationId = notification.NotificationId;
            userNotification.UserId = user.Id;

            _repositoryManager.UserNotification.AddUserNotification(userNotification);
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
