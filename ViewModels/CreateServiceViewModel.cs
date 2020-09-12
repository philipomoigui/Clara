using Clara.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.ViewModels
{
    public class CreateServiceViewModel
    {
        public Guid ServiceId { get; set; }
        public ServiceProviders ServiceType { get; set; }
        public string ServiceName { get; set; }
        public string Email { get; set; }
        public string AddressLine { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public List<string> AddOns { get; set; }
    }
}
