using Clara.DataAccess;
using Clara.Infrastructure;
using Clara.Models;
using Clara.Repository.Interface;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        private readonly IHubContext<SignalServer> _hubContext;

        public NotificationRepository(ApplicationDbContext applicationDbContext, IHubContext<SignalServer> hubContext) : base(applicationDbContext)
        {
            _hubContext = hubContext;
        }
        public void AddNotification(Notification notification)
        {
            Create(notification);

            _hubContext.Clients.All.SendAsync("displayNotification", "");
        }

        public void ReadNotification(Guid NotificationId)
        {
           var notification = FindByCondition(n => n.NotificationId == NotificationId)
                 .FirstOrDefault();

            notification.Read = true;
            Update(notification);
        }
    }
}
