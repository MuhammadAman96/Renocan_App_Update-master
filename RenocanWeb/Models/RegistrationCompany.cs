using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RenocanWeb.Models
{
   
    public class RegistrationCompany : Message
    {
        public int? Company_ID { get; set; }


        [AllowHtml]
        [Required]
        [RegularExpression(@"^([a-zA-Z\s'-]{3,50})$", ErrorMessage = "Please Enter Valid Name")]
         public string CompanyName { get; set; }


        [Required]
        public string PostalCode { get; set; }


        [AllowHtml]
        [Required(ErrorMessage = "Please Enter Cell Phone Number")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Please Enter Valid Cell Phone Number")]
        public string PhoneNumber { get; set; }


        [AllowHtml]
        [Required]
        [EmailAddress(ErrorMessage = "Please Enter a Valid Email Address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Create_Password { get; set; }

   

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Create_Password")]
        public string Confirm_Password { get; set; }


        [Required(ErrorMessage = "Please Enter Owner_First_Name")]
        [RegularExpression(@"^([a-zA-Z\s'-]{3,50})$", ErrorMessage = "Please Enter Valid Name")]
        public string Owner_First_Name { get; set; }

        [Required(ErrorMessage = "Please Enter Owner_Last_Name")]
        [RegularExpression(@"^([a-zA-Z\s'-]{3,50})$", ErrorMessage = "Please Enter Valid Name")]
        public string Owner_Last_Name { get; set; }


        public int BusinessCategoryId { get; set; }
        public IEnumerable<SelectListItem> BusinessCategoryList { get; set; }

        public int LocationId { get; set; }
        public IEnumerable<SelectListItem> LocationList { get; set; }

    }

    public class Company_Activity : Message
    {
        public int Review_ID { get; set; }
        public string ReviewedDate { get; set; }
        public string Service_Review_Status { get; set; }
        public string FullName { get; set; }
        public string Review_Title { get; set; }
        public string Review_Details { get; set; }
    }

    public class Company_ActivityVM : Message
    {
        public Company_ActivityVM()
        {
            ComActivityList = new List<Company_Activity>();
        }
        public List<Company_Activity> ComActivityList { get; set; }
    }



}