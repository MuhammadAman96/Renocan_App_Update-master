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
        [Required(ErrorMessage = "Please Enter Full Name")]
        [StringLength(50, ErrorMessage = "Full Name Shouldn't be Exceed from 50 Characters")]
        [RegularExpression(@"^([a-zA-Z\s'-]{3,50})$", ErrorMessage = "Please Enter Valid Name")]
        public string First_Name { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Please Enter Full Name")]
        [StringLength(50, ErrorMessage = "Full Name Shouldn't be Exceed from 50 Characters")]
        [RegularExpression(@"^([a-zA-Z\s'-]{3,50})$", ErrorMessage = "Please Enter Valid Name")]
        public string Last_Name { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Please Enter Full Name")]
        [StringLength(50, ErrorMessage = "Full Name Shouldn't be Exceed from 50 Characters")]
        [RegularExpression(@"^([a-zA-Z\s'-]{3,50})$", ErrorMessage = "Please Enter Valid Name")]
        public string City { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Please Enter Full Name")]
        [StringLength(50, ErrorMessage = "Full Name Shouldn't be Exceed from 50 Characters")]
        [RegularExpression(@"^([a-zA-Z\s'-]{3,50})$", ErrorMessage = "Please Enter Valid Name")]
        public string State { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Please Enter a Valid Email Address")]
        public string Email { get; set; }

        public string Create_Password { get; set; }

        public string Confirm_Password { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Please Enter Cell Phone Number")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Please Enter Valid Cell Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please Enter Cell Phone Number")]
        public string IsNewsletter { get; set; }

    }
}