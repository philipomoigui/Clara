using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Clara.Models
{
    public class ApplicationUser: IdentityUser
    {
        public List<Service> Services { get; set; }
        public List<Comment> Comments { get; set; }
        public UserProfile UserProfile { get; set; }
        public List<Bookmark> Bookmarks { get; set; }
        public List<NotificationApplicationUser> NotificationUsers { get; set; }
    }
}
