﻿using Clara.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Models
{
    public class Service
    {
        public Guid ServiceId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessEmail { get; set; }
        public string PhoneNumber { get; set; }
        public decimal EstimatedPrice { get; set; }
        public string ImageURL { get; set; }
        public string AddressLine { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public List<AddOns> AddOns { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid UserId { get; set; }
    }
}
