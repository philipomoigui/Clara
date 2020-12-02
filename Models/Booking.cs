using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Models
{
    public class Booking
    {
        public Guid BookingId { get; set; }
        public Guid ServiceId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int ExpectedGuests { get; set; }
        public string AdditionalDetails { get; set; }
    }
}
