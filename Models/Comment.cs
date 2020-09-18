using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
