using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Models
{
    public class Notification
    {
        public Guid NotificationId { get; set; }
        public string Text { get; set; }
        public bool Read { get; set; } = false;
        public List<NotificationApplicationUser> NotificationUsers { get; set; }
    }
}
