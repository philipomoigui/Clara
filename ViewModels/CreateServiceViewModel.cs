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
        [Required]
        [MaxLength(200, ErrorMessage = "Name cannot be over 200 Chracters")]
        public string BusinessName { get; set; }

        [Required]
        [Display(Name = "Business Email")]
        [EmailAddress]
        [MaxLength(200, ErrorMessage = "Email cannot be over 200 Chracters")]
        public string BusinessEmail { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Address cannot be over 200 Chracters")]
        public string AddressLine { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "City cannot be over 100 Chracters")]
        public string City { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "State cannot be over 100 Chracters")]
        public string State { get; set; }

        [Required]
        [MaxLength(100)]
        public string ZipCode { get; set; }
        //public string Country { get; set; }

        [Display(Name = "Contact Number")]
        [Required]
        [MaxLength(11, ErrorMessage = "Contact Number cannot be more than 11 characters")]
        public string PhoneNumber { get; set; }
        [Required]
        public List<IFormFile> Photos { get; set; }
        [Required]
        [MaxLength(200,ErrorMessage = "Amenities cannot be more than 200 chracters" )]
        public string Amenities { get; set; }

        [Required]
        [MaxLength(400, ErrorMessage = "Amenities cannot be more than 400 chracters")]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Category> Categories { get; set; }
    }
}
