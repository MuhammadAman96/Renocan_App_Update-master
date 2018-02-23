using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RenocanWeb.Models
{
    public class Client_Signup : Message
    {
        public int Client_ID { get; set; }

        [AllowHtml]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
        [Required(ErrorMessage = "Please Enter First Name")]
        public string First_Name { get; set; }

        [AllowHtml]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string Last_Name { get; set; }

        [AllowHtml]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
        [Required(ErrorMessage = "Please Enter City")]
        public string City { get; set; }

        [AllowHtml]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
        [Required(ErrorMessage = "Please Enter State")]
        public string State { get; set; }

        [AllowHtml]
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Create_Password { get; set; }


        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Create_Password")]
        public string Confirm_Password { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Please Enter Cell Phone Number")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Please Enter Valid Cell Phone Number")]
        public string Phone { get; set; }

        public bool IsNewsletter { get; set; }

    }
}