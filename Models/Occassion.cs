using Clara.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Models
{
    public class Occassion
    {
        public int OccasionId { get; set; }
        public EventKind OccasionKind { get; set; }
    }
}
