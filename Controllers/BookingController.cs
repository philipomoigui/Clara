using System.Threading.Tasks;
using AutoMapper;
using Clara.Infrastructure;
using Clara.Models;
using Clara.Repository.Interface;
using Clara.Utility;
using Clara.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Clara.Controllers
{
    public class BookingController : Controller
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHubContext<SignalServer> _hubContext;
        private readonly IEmailSender _emailSender;

        public BookingController(IRepositoryManager repositoryManager, IMapper mapper, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IHubContext<SignalServer> hubContext, IEmailSender emailSender)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _signinManager = signInManager;
            _userManager = userManager;
            _hubContext = hubContext;
            _emailSender = emailSender;
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

                Notification notification = new Notification();
                notification.Text = $"{model.FirstName} {model.LastName} made a request to book your service, {service.BusinessName}";

                _repositoryManager.Notification.AddNotification(notification);

                NotificationApplicationUser userNotification = new NotificationApplicationUser();
                userNotification.NotificationId = notification.NotificationId;
                userNotification.UserId = service.User.Id;

                _repositoryManager.UserNotification.AddUserNotification(userNotification);
                await _repositoryManager.saveAsync();

                await _hubContext.Clients.All.SendAsync("displayNotification", "");

                await _emailSender.sendEmailAsync(model.Email, "Listing Successfully Booked", $"Hello {model.FirstName}, we are glad to inform you that the service {service.BusinessName}, you requested to book has been successfully booked <br/> </br> You will be contacted with further details shortly.");
                await _emailSender.sendEmailAsync(service.User.Email, $"Your service {service.BusinessName} was just successfully booked!", "Hello, <br/> find attached below the details of the user that recently just booked your service. We hope you adhere to our User Policies while dealing with Users.");

                return RedirectToAction(nameof(Success));
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }

      
    }
}
