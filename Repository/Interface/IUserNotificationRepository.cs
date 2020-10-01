using Clara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository.Interface
{
    public interface IUserNotificationRepository
    {
        List<NotificationApplicationUser> GetUserNotofications(string userId);
        void AddUserNotification(NotificationApplicationUser userNotification);
    }
}
