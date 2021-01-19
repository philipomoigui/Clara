using System;

namespace Clara.Models
{
    public class AddOns
    {
        public Guid AddOnsId { get; set; }
        public string Addons { get; set; }
        public string Others { get; set; }
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
    }
}