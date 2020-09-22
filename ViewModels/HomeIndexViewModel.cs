using Clara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<Service> PopularFood { get; set; }
        public List<Service> PopularHalls { get; set; }
        public List<Service> PopularMedia { get; set; }
        public List<Service> PopularPlanner { get; set; }
        public List<Service> PopularAccomodation { get; set; }
        public List<Service> PopularLogistics { get; set; }
        public List<Category> CategoryList { get; set; }

    }
}
