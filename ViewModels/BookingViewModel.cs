using Clara.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.ViewModels
{
    public class BookingViewModel
    {
        public Guid BookingId { get; set; }
        public Guid ServiceId { get; set; }
        public string UserId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Your Name cannot be more than 100 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Your Last Name cannot be more than 100 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Your Email cannot be more than 100 characters")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(12, ErrorMessage = "Your review cannot be more than 300 characters")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Expected Guests")]
        [Range(minimum: 1, maximum: 1000, ErrorMessage = "The expected guests should be between 1 and 1000")]
        public int ExpectedGuests { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "Your Additional Details cannot be more than 300 characters")]
        [Display(Name = "Additional Details")]
        public string AdditionalDetails { get; set; }
    }
}
