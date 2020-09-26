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
    public class UserRepository : RepositoryBase<UserProfile>, IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void AddUserProfile(UserProfile userProfile)
        {
            Create(userProfile);
        }

        public UserProfile GetUserProfile(string userId)
        {
            return FindByCondition(u => u.UserId == userId).FirstOrDefault();
        }

        //public IQueryable<Service> GetUSerServices(string userId)
        //{
        //    return _applicationDbContext.Services
        //        .Where(u => u.UserId == userId)
        //         .AsNoTracking()
        //         .Include(s => s.Category)
        //         .OrderBy(s => s.BusinessName);
        //}

        public void UpdateUserProfile(UserProfile userProfile)
        {
            Update(userProfile);
        }
    }
}
