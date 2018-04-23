using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Password is required.")]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is required.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password length must be between 6 and 20.")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("NewPassword", ErrorMessage = "Password doesn't match..")]
        public string ConfirmPassword { get; set; }

        public string SuccessMessage { get; set; }
    }
}