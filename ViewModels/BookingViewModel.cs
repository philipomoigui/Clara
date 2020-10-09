using Clara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.ViewModels
{
    public class BookingViewModel
    {
        public Guid BookingId { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AdditionalDetails { get; set; }
    }
}
