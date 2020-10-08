using Clara.DataAccess;
using Clara.Infrastructure;
using Clara.Models;
using Clara.Repository.Interface;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository
{
    public class UserNotificationRepository : RepositoryBase<NotificationApplicationUser>, IUserNotificationRepository
    {
        private readonly IHubContext<SignalServer> _hubContext;

        public UserNotificationRepository(ApplicationDbContext applicationDbContext, IHubContext<SignalServer> hubContext): base(applicationDbContext)
        {
            _hubContext = hubContext;
        }

        public void AddUserNotification(NotificationApplicationUser userNotification)
        {
            Create(userNotification);

            _hubContext.Clients.All.SendAsync("displayNotification", "");
        }

        public List<NotificationApplicationUser> GetUserNotofications(string userId)
        {
           return  FindByCondition(n => n.UserId == userId && !n.Notification.Read)
                .Include(n => n.Notification)
                .ToList();
        }
    }
}
