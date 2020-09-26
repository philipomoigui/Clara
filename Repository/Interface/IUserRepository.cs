using Clara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository.Interface
{
    public interface IUserRepository
    {
        void AddUserProfile(UserProfile userProfile);
        public UserProfile GetUserProfile(string userId);
        void UpdateUserProfile(UserProfile userProfile);

    }
}
