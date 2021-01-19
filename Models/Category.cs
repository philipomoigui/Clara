using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clara.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Service> Services { get; set; }
    }
}
