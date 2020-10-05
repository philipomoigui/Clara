using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Models
{
    public class Bookmark
    {
        public Guid BookmarkId { get; set; }
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
 