using Clara.Models;
using Clara.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.ViewModels
{
    public class CreateServiceViewModel
    {
        public Guid ServiceId { get; set; }

        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }

        [Display(Name = "Business Email")]
        public string BusinessEmail { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        //public string Country { get; set; }

        [Display(Name = "Contact Number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Currency)]
        //public decimal Price { get; set; }
        //public IFormFile Photo { get; set; }

        public string Description { get; set; }
        //public List<string> AddOns { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Category> Categories { get; set; }
    }
}
