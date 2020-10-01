using Clara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository.Interface
{
    public interface INotificationRepository
    {
        void AddNotication(Notification notification);
        void ReadNotification(Guid NotificationId);
    }
}
