using System;
using System.Collections.Generic;

namespace Clara.Models
{
    public class Service
    {
        public Guid ServiceId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageURL { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Description { get; set; }
        public string Amenities { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public UserProfile UserProfile { get; set; }
        public List<Bookmark> Bookmarks { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
