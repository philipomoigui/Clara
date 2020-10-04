using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.ViewModels
{
    public class UserSecurityViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password and Confirm Password do not match")]
        public string ConfirmPassword { get; set; }
        public DateTime DateChanged { get; set; } = DateTime.UtcNow;
        public string RelativeDateChange { get; set; }
    }
}
