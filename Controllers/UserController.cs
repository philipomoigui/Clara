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

        public UserController(IMapper mapper, IRepositoryManager repositoryManager, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
            _userManager = userManager;
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
