﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Models
{
    public class UserProfile
    {
        public Guid UserProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string About { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public DateTime? PasswordChangeDate { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
