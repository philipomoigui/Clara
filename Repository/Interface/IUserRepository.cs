using Clara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository.Interface
{
    public interface IUserRepository
    {
        Task AddUserProfileAsync(UserProfile userProfile);
        IQueryable<Service> GetUSerServices(string userId);
        UserProfile GetUserProfile(string userId);
        void UpdateUserProfile(string userId);
        Task<bool> complete();

    }
}
