using Clara.DataAccess;
using Clara.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private ApplicationDbContext _applicationDbContext;
        private IServicesRepository _servicesRepository;
        private ICommentRepository _commentRepository;
        private IUserRepository _userRepository;
        private ICategoryRepository _categoryRepository;
        private INotificationRepository _NotificationRepository;
        private IUserNotificationRepository _UserNotificationRepository;

        public RepositoryManager(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
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
                    _NotificationRepository = new NotificationRepository(_applicationDbContext);
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
                    _UserNotificationRepository = new UserNotificationRepository(_applicationDbContext);
                }
                return _UserNotificationRepository;
            }
        }

        public async Task saveAsync()
        {
            await  _applicationDbContext.SaveChangesAsync();
        }
    }
}
