using Clara.DataAccess;
using Clara.Models;
using Clara.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository
{
    public class UserNotificationRepository : RepositoryBase<NotificationApplicationUser>, IUserNotificationRepository
    {
        public UserNotificationRepository(ApplicationDbContext applicationDbContext): base(applicationDbContext)
        {

        }

        public void AddUserNotification(NotificationApplicationUser userNotification)
        {
            Create(userNotification);
        }

        public List<NotificationApplicationUser> GetUserNotofications(string userId)
        {
           return  FindByCondition(n => n.UserId == userId)
                .Include(n => n.Notification)
                .ToList();
        }
    }
}
