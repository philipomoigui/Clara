using System;

namespace Clara.Models
{
    public class Event
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public int ExpectedGuests { get; set; }
        public DateTime DateOfEvent { get; set; }
    }
}
