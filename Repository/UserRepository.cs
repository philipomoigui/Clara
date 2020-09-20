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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task AddUserProfileAsync(UserProfile userProfile)
        {
            await _applicationDbContext.UserProfiles.AddAsync(userProfile);
        }

        public async Task<bool> complete()
        {
            return (await _applicationDbContext.SaveChangesAsync() >= 0);
        }

        public UserProfile GetUserProfile(string userId)
        {
           return  _applicationDbContext.UserProfiles.FirstOrDefault(u => u.UserId == userId);
        }

        public IQueryable<Service> GetUSerServices(string userId)
        {
            return _applicationDbContext.Services.Where(u => u.UserId == userId)
                 .AsNoTracking()
                 .OrderBy(s => s.BusinessName);
        }

        public void UpdateUserProfile(string userId)
        {
            var userProfile = GetUserProfile(userId);
            _applicationDbContext.Update(userProfile);

        }
    }
}
