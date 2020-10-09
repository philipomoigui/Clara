using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clara.Models;
using Clara.Repository;
using Clara.Repository.Interface;
using Clara.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Clara.Controllers
{
    public class BookingController : Controller
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookingController(IRepositoryManager repositoryManager, IMapper mapper, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _signinManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Booking()
        {
            if (_signinManager.IsSignedIn(User))
            {
                var userId = _userManager.GetUserId(User);
               var userProfile =  _repositoryManager.UserProfile.GetUserProfile(userId);
               var profile =  _mapper.Map<BookingViewModel>(userProfile);
               return View(profile);
            }


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Booking(BookingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _repositoryManager.UserProfile.GetUserProfile(model.UserId);

                if (model.ServiceId == null)
                    return NotFound();

                var service = await _repositoryManager.Service.GetServiceById(model.ServiceId);
                if (service == null)
                    return NotFound();

                var booking = _mapper.Map<Booking>(model);
                _repositoryManager.Booking.AddBooking(booking);
                await _repositoryManager.saveAsync();

                Notification notification = new Notification();
                notification.Text = $"{user.FirstName} {user.LastName} made a request to book your service, {service.BusinessName}";

                _repositoryManager.Notification.AddNotification(notification);

                NotificationApplicationUser userNotification = new NotificationApplicationUser();
                userNotification.NotificationId = notification.NotificationId;
                userNotification.UserId = service.User.Id;

                _repositoryManager.UserNotification.AddUserNotification(userNotification);
                await _repositoryManager.saveAsync();
                return RedirectToAction(nameof(Success));
            }

            return View();
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
