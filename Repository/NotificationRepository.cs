using Clara.DataAccess;
using Clara.Models;
using Clara.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
       
        public NotificationRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            
        }
        public void AddNotication(Notification notification)
        {
            Create(notification);
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
