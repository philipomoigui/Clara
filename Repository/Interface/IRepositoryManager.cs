using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository.Interface
{
    public interface IRepositoryManager
    {
        IServicesRepository Service { get; }
        ICommentRepository Comment { get; }
        IUserRepository UserProfile { get; }
        ICategoryRepository Category { get; }
        INotificationRepository Notification { get;}
        IUserNotificationRepository UserNotification { get; }
        IBookmarkRepository Bookmark { get; }
        IBookingRepository Booking { get; }
        Task saveAsync();
    }
}
