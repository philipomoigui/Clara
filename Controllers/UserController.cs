using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clara.Extension_Methods;
using Clara.Infrastructure;
using Clara.Models;
using Clara.Repository.Interface;
using Clara.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Clara.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHubContext<SignalServer> _hubContext;

        public UserController(IMapper mapper, IRepositoryManager repositoryManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHubContext<SignalServer> hubContext)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _hubContext = hubContext;
        }

        [HttpGet]
        public IActionResult Account()
        {
            var userId = _userManager.GetUserId(User);
            var userProfile = _repositoryManager.UserProfile.GetUserProfile(userId);
            if (userProfile == null)
                return NotFound();

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
            var userId = _userManager.GetUserId(User);
            var userProfile = _repositoryManager.UserProfile.GetUserProfile(userId);
            var userServices = _repositoryManager.Service.GetUSerServices(userId).ToList();
            var userComments = _repositoryManager.Comment.GetUserComments(userId).ToList();
            
            if (userProfile == null)
                return NotFound();

            var model = _mapper.Map<UserProfileViewModel>(userProfile);
            model.Services = userServices;
            model.UserId = UserIdReform(userId);
            model.Comments = userComments;

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

            if (profile.PasswordChangeDate != null)
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

        [HttpGet]
        public IActionResult Bookmark()
        {
            var userId = _userManager.GetUserId(User);
            var userProfile = _repositoryManager.UserProfile.GetUserProfile(userId);

            var model = _mapper.Map<UserProfileViewModel>(userProfile);

            model.Bookmarks = _repositoryManager.Bookmark.GetUserBookmarks(userId).ToList();

            return View(model);
        }
        public async Task<IActionResult> Bookmarked(string userId, Guid serviceId)
        {
            var message = string.Empty;
            var service = await _repositoryManager.Service.GetServiceById(serviceId);

           if(userId == null || serviceId == null)
            {
                message = "You need to be signed in to add this service to your bookmark";
            } else
            {
                var userBookmark = _repositoryManager.Bookmark.isServiceBookmarked(userId, serviceId);

                if (userBookmark == null)
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

                    Notification notification = new Notification
                    {
                        Text = $"Someone bookmarked your service {service.BusinessName}"
                    };

                    _repositoryManager.Notification.AddNotification(notification);

                    NotificationApplicationUser userNotification = new NotificationApplicationUser();
                    userNotification.NotificationId = notification.NotificationId;
                    userNotification.UserId = service.User.Id;

                    _repositoryManager.UserNotification.AddUserNotification(userNotification);

                    await _repositoryManager.saveAsync();

                    await _hubContext.Clients.All.SendAsync("displayNotification", "");

                }
                else
                {
                    _repositoryManager.Bookmark.DeleteFromBookMark(userBookmark);
                    await _repositoryManager.saveAsync();
                    message = "This service has been removed from your bookmark";
                }
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
            TimeSpan timespan = DateTime.UtcNow - dateChanged;
            if (timespan.TotalMinutes < 1)
                return "just now";

            if (timespan.TotalHours < 1)
                return (int)timespan.TotalMinutes == 1 ? "1 Minute ago" : (int)timespan.TotalMinutes + " Minutes ago";

            if (timespan.TotalDays < 1)
                return (int)timespan.TotalHours == 1 ? "an Hour ago" : (int)timespan.TotalHours + " Hours ago";

            if (timespan.TotalDays < 7)
                return (int)timespan.TotalDays == 1 ? "1 Day ago" : (int)timespan.TotalDays + " Days ago";

            if (timespan.TotalDays < 30.4368)
                return (int)(timespan.TotalDays / 7) == 1 ? "1 Week ago" : (int)(timespan.TotalDays / 7) + " Weeks ago";

            if (timespan.TotalDays < 365.242)
                return (int)(timespan.TotalDays / 30.4368) == 1 ? "1 Month ago" : (int)(timespan.TotalDays / 30.4368) + " Months ago";

            return (int)(timespan.TotalDays / 365.242) == 1 ? "1 Year ago" : (int)(timespan.TotalDays / 365.242) + " Years ago";
        }


    }
}
