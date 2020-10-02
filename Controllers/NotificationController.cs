using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clara.Models;
using Clara.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Clara.Controllers
{
    public class NotificationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepositoryManager _repositoryManager;

        public NotificationController(UserManager<ApplicationUser> userManager, IRepositoryManager repositoryManager)
        {
            _userManager = userManager;
            _repositoryManager = repositoryManager;
        }
        public IActionResult GetNotification()
        {
           var userId = _userManager.GetUserId(User);
           var notifications = _repositoryManager.UserNotification.GetUserNotofications(userId);
            //var jsonnotification = JsonConvert.SerializeObject(notifications, Formatting.Indented);

            return Ok(new { UserNotification = notifications, Count = notifications.Count() });
        }

        public IActionResult FileNotification()
        {
            var files = Request.Form.Files;
            var message = string.Empty;

            if (files.Count > 0)
            {
                message = "The files got here Successfully";
            }

            return Json(message);
        }

        public async Task<IActionResult> ReadNotification(Guid notificationId)
        {
            _repositoryManager.Notification.ReadNotification(notificationId);
            await _repositoryManager.saveAsync();
            return Ok();
        }
    }
}
