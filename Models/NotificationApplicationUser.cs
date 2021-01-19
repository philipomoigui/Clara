using System;

namespace Clara.Models
{
    public class NotificationApplicationUser
    {
        public Guid NotificationId { get; set; }
        public Notification Notification { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
