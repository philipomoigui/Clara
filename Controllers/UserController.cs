using System;
using System.Collections.Generic;
using System.Globalization;
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
            TextInfo titleCase = new CultureInfo("en-US", false).TextInfo;
            
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var profile = _repositoryManager.UserProfile.GetUserProfile(userId);

                if (profile == null)
                    return NotFound();

                if (model.FirstName != null && model.LastName != null && model.PhoneNumber != null)
                {
                    profile.FirstName = model.FirstName.Capitalize();
                    profile.LastName = model.LastName.Capitalize();
                    profile.PhoneNumber = model.PhoneNumber;
                }
                if (model.AddressLine  != null && model.City != null && model.State != null)
                {
                    profile.AddressLine = titleCase.ToTitleCase(model.AddressLine);
                    profile.City = model.City.Capitalize();
                    profile.State = model.State.Capitalize();

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
            var userId = _userManager.GetUserId(User);
            UserSecurityViewModel model = new UserSecurityViewModel();
           var profile =  _repositoryManager.UserProfile.GetUserProfile(userId);
            

            model.RelativeDateChange = RelativeDateTime((DateTime)profile.PasswordChangeDate);

            return View(model);
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
                    UserProfile userProfile = new UserProfile();
                    userProfile.PasswordChangeDate = model.DateChanged;

                    _repositoryManager.UserProfile.UpdateUserProfile(userProfile);
                    await _signInManager.RefreshSignInAsync(user);
                    TempData["SuccessMessage"] = "Password Updated Successfully";
                    RedirectToAction(nameof(Security));
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }


            return View(model);
        }

        [HttpGet]
        public IActionResult Test()
        {
            return View();
        }

        public async Task<IActionResult> Bookmarked(string userId, Guid serviceId)
        {
            var message = string.Empty;

           if(userId == null || serviceId == null)
            {
                message = "You need to be signed in to add this service to your bookmark";
            }

            var userBookmark = _repositoryManager.Bookmark.GetUserBookmark(userId, serviceId);

            if(userBookmark == null)
            {
                Bookmark bookmark = new Bookmark
                {
                    ServiceId = serviceId,
                    UserId = userId,
                    DateCreated = DateTime.Now
                };

                _repositoryManager.Bookmark.AddToBookmark(bookmark);
                await _repositoryManager.saveAsync();
                message = "This service has been added you your bookmark";
            }
            if (userBookmark != null)
            {
                _repositoryManager.Bookmark.DeleteFromBookMark(userBookmark);
               await  _repositoryManager.saveAsync();
                message = "This service has been removed from your bookmark";
            }

            return Json(message);
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

        public string RelativeDateTime(DateTime dateChanged)
        {
            const int SECOND = 1;
            const int MINUTE = 1 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var timespan = new TimeSpan(DateTime.UtcNow.Ticks - dateChanged.Ticks);
            double totalSeconds = Math.Abs(timespan.TotalSeconds);

            if(totalSeconds < 1 * MINUTE)
            {
                return timespan.Seconds == 1 ? "Just Now" : timespan.Seconds + " seconds ago";
            }
            if (totalSeconds < 2 * MINUTE)
            {
                return "a minute ago";
            }
            if (totalSeconds < 45 * MINUTE)
            {
                return timespan.Seconds > 30 && timespan.Seconds < 40 ? "30 minutes ago" : timespan.Minutes + " minutes ago";
            }
            if (totalSeconds < 90 * MINUTE)
            {
                return timespan.Seconds > 60 && timespan.Seconds < 90 ? "an hour ago" : timespan.Minutes + " minutes ago";
            }
            if (totalSeconds < 24 * HOUR)
            {
                return timespan.Hours + " hours ago";
            }
            if (totalSeconds < 48 * HOUR)
            {
                return "yesterday";
            }
            if (totalSeconds < 30 * DAY)
            {
                return timespan.Days + " days ago";
            }
            if (totalSeconds < 12 * MONTH)
            {
                int month = Convert.ToInt32(Math.Floor((double)timespan.Days / 30));
                return month < 1 ? "a month ago" : month + " months ago";
            } 
            else
            {
                int year = Convert.ToInt32(Math.Floor((double)timespan.Days / 365));
                return year < 1 ? "a year ago" : year + " years ago";
            }
        }


    }
}
