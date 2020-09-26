using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clara.Extension_Methods;
using Clara.Models;
using Clara.Repository.Interface;
using Clara.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Clara.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(IMapper mapper, IRepositoryManager repositoryManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Account()
        {
            var userId = _userManager.GetUserId(User);
            var userProfile = _repositoryManager.UserProfile.GetUserProfile(userId);
            ViewBag.FirstName = userProfile.FirstName.Capitalize();
            return View();
        }

        [HttpGet]
        public IActionResult Personal(string Id)
        {
            var userProfile = _repositoryManager.UserProfile.GetUserProfile(Id);

            if (userProfile == null)
                return NotFound();

           var model =  _mapper.Map<UserProfileViewModel>(userProfile);
           model.UserId = UserIdReform(Id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Personal(UserProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var profile = _repositoryManager.UserProfile.GetUserProfile(userId);

                if (profile == null)
                    return NotFound();

                if (model.FirstName != null && model.LastName != null && model.PhoneNumber != null)
                {
                    profile.FirstName = model.FirstName;
                    profile.LastName = model.LastName;
                    profile.PhoneNumber = model.PhoneNumber;
                }
                if (model.AddressLine  != null && model.City != null && model.State != null)
                {
                    profile.AddressLine = model.AddressLine;
                    profile.City = model.City;
                    profile.State = model.State;

                }

                if(model.About != null)
                {
                    profile.About = model.About;
                }

                _repositoryManager.UserProfile.UpdateUserProfile(profile);
                await _repositoryManager.saveAsync();
                return RedirectToAction("Personal", new { Id = userId});
            }

            return View();
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var Id = _userManager.GetUserId(User);
            var userProfile = _repositoryManager.UserProfile.GetUserProfile(Id);
            var userServices = _repositoryManager.Service.GetUSerServices(Id).ToList();

            if (userProfile == null)
                return NotFound();

            var model = _mapper.Map<UserProfileViewModel>(userProfile);
            model.Services = userServices;
            model.UserId = UserIdReform(Id);

            return View(model);
        }

        [HttpPost]
        public async void Profile(string about)
        {
            if (!string.IsNullOrEmpty(about))
            {
                var userId = _userManager.GetUserId(User);
                var profile = _repositoryManager.UserProfile.GetUserProfile(userId);
                profile.About = about;
                _repositoryManager.UserProfile.UpdateUserProfile(profile);
                await _repositoryManager.saveAsync();
            }
        }

        [HttpGet]
        public IActionResult Security()
        {
            
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Security(UserSecurityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    RedirectToAction("Login", "Account");
                }

               var result = await  _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if (result.Succeeded)
                {
                    await _signInManager.RefreshSignInAsync(user);
                    RedirectToAction(nameof(Security));
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }


            return View(model);
        }

        public string UserIdReform(string userId)
        {
            var userIdArr = userId.Split("-");
            var result = string.Empty;
           for(var i = 0; i < userIdArr.Length; i++)
            {
                result = userIdArr[0].ToUpper();
            };
            return result;
        }



    }
}
