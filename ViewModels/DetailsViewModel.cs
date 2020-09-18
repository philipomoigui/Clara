using Clara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.ViewModels
{
    public class DetailsViewModel
    {
        public Service Service { get; set; }
        public IEnumerable<Service> RandomServices { get; set; }
    }
}
