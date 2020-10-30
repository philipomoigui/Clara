using Clara.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.ViewModels
{
    public class DetailsViewModel
    {
        public Service Service { get; set; }
        public IEnumerable<Service> RandomServices { get; set; }

        [Required]
        [MaxLength(300, ErrorMessage = "Your review cannot be more than 300 characters")]
        public string Message { get; set; }

        [Required]
        public double Rating { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string UserId { get; set; }
        public Guid ServiceId { get; set; }
        public int CategoryId { get; set; }
        public List<string> Amenities { get; set; }
        public List<string> PhotoUrl { get; set; }
        public List<Comment> Comments { get; set; }
        public bool isBookmarked { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
