using Clara.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Clara.Models
{
    public class Occassion
    {
        [Key]
        public Guid OccasionId { get; set; }
        public EventKind OccasionKind { get; set; }
    }
}
