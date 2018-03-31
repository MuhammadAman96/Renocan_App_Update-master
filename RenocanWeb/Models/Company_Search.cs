using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RenocanWeb.Models
{
    public class Company_Search:Message
    {
        [AllowHtml]
        [Required]

        public string CompanyName { get; set; }


        [AllowHtml]
        [Required]
        [RegularExpression(@"^([a-zA-Z\s'-]{3,50})$", ErrorMessage = "Please Enter Valid Name")]
        public string Location { get; set; }
    }
}