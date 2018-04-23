using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
   
        public class PasswordRecoveryConfirm
        {
            [Required(ErrorMessage = "Password is required")]
            [StringLength(20, MinimumLength = 5  , ErrorMessage = "Password length must be between 6 and 20.")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Confirm Password is required")]
            [Compare("Password", ErrorMessage = "Password doesn't match.")]
            public string ConfirmPassword { get; set; }

            public bool DisablePasswordChanging { get; set; }
            public string Message { get; set; }
        

    }
}