using Clara.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Models
{
    public class Occassion
    {
        [Key]
        public Guid OccasionId { get; set; }
        public EventKind OccasionKind { get; set; }
    }
}
