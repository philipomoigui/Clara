using Clara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.ViewModels
{
    public class DetailsViewModel
    {
        public Service Service { get; set; }
        public IEnumerable<Service> RandomServices { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string UserId { get; set; }
        public Guid ServiceId { get; set; }
        public int CategoryId { get; set; }
        public List<Comment> Comments { get; set; }
        public bool isBookmarked { get; set; }
    }
}
