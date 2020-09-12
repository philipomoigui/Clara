using Clara.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public ServiceProviders CategoryName { get; set; }
        public List<Service> Services { get; set; }
    }
}
