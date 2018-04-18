using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RenocanWeb.Models
{
    public class Login:Message
    {

        [AllowHtml]
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [AllowHtml]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
        [Required(ErrorMessage = "Please Enter State")]
        public string Password { get; set; }
    }

    public class Forget_Pass :Message
    {

        [AllowHtml]
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


    }

}