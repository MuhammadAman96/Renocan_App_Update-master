using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class PasswordRecovery
    {
        
            [Required(ErrorMessage = "Email is required")]
            [StringLength(100, ErrorMessage = "Email is too long")]
            public string Email { get; set; }

            public string Message { get; set; }
        
    }
}