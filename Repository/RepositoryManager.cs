using Clara.DataAccess;
using Clara.Infrastructure;
using Clara.Repository.Interface;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private ApplicationDbContext _applicationDbContext;
        private readonly IHubContext<SignalServer> hubContext;
        private IServicesRepository _servicesRepository;
        private ICommentRepository _commentRepository;
        private IUserRepository _userRepository;
        private ICategoryRepository _categoryRepository;
        private INotificationRepository _NotificationRepository;
        private IUserNotificationRepository _UserNotificationRepository;
        private IBookmarkRepository _bookmarkRepository;
        private IBookingRepository _bookingRepository;

        public RepositoryManager(ApplicationDbContext applicationDbContext, IHubContext<SignalServer> hubContext)
        {
            _applicationDbContext = applicationDbContext;
            this.hubContext = hubContext;
        }

        public IServicesRepository Service
        {
            get
            {
                if(_servicesRepository == null)
                {
                    _servicesRepository = new ServiceRepository(_applicationDbContext);
                }
                return _servicesRepository;
            }
        }

        public ICommentRepository Comment
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(_applicationDbContext);
                }
                return _commentRepository;
            }
        }

        public IUserRepository UserProfile
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_applicationDbContext);
                }
                return _userRepository;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_applicationDbContext);
                }
                return _categoryRepository;
            }
        }

        public INotificationRepository Notification
        {
            get
            {
                if (_NotificationRepository == null)
                {
                    _NotificationRepository = new NotificationRepository(_applicationDbContext, hubContext);
                }
                return _NotificationRepository;
            }
        }

        public IUserNotificationRepository UserNotification
        {
            get
            {
                if (_UserNotificationRepository == null)
                {
                    _UserNotificationRepository = new UserNotificationRepository(_applicationDbContext, hubContext);
                }
                return _UserNotificationRepository;
            }
        }

        public IBookmarkRepository Bookmark
        {
            get
            {
                if (_bookmarkRepository == null)
                {
                    _bookmarkRepository = new BookmarkRepository(_applicationDbContext);
                }
                return _bookmarkRepository;
            }
        }

        public IBookingRepository Booking
        {
            get
            {
                if (_bookingRepository == null)
                {
                    _bookingRepository = new BookingRepository(_applicationDbContext);
                }
                return _bookingRepository;
            }
        }

        public async Task saveAsync()
        {
            await  _applicationDbContext.SaveChangesAsync();
        }
    }
}
