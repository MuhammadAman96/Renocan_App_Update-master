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
        [Required(ErrorMessage = "Please Enter Full Company Name")]
        [RegularExpression(@"^([a-zA-Z\s'-]{3,50})$", ErrorMessage = "Please Enter Valid Name")]
         public string CompanyName { get; set; }


        [Required(ErrorMessage = "Please Enter Postal Code")]
        public string PostalCode { get; set; }


        [AllowHtml]
        [Required(ErrorMessage = "Please Enter Cell Phone Number")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Please Enter Valid Cell Phone Number")]
        public string PhoneNumber { get; set; }


        [AllowHtml]
        [Required(ErrorMessage = "Please Enter Email")]
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

        public Nullable<bool> IsAggrement { get; set; }


        public Nullable<bool> Is_Paid { get; set; }


        //[Required(ErrorMessage = "Please Enter Website_Add")]
        public string Website_Add { get; set; }


        //[Required(ErrorMessage = "Please Enter Bussiness_Description")]
        public string Bussiness_Description { get; set; }


       // [Required(ErrorMessage = "Please Enter Profile_Information")]
        public string Profile_Information { get; set; }

        //[Required(ErrorMessage = "Please Enter Products")]
        public string Products { get; set; }


        //[Required(ErrorMessage = "Please Enter Services")]
        public string Services { get; set; }


        //[Required(ErrorMessage = "Please Enter Brands")]
        public string Brands { get; set; }


        //[Required(ErrorMessage = "Please Enter Specialities")]
        public string Specialities { get; set; }


        //[Required(ErrorMessage = "Please Enter Year_Established")]
        public string Year_Established { get; set; }

        //[Required(ErrorMessage = "Please Enter Return_Policy_URL")]
        public string Return_Policy_URL { get; set; }


        //[Required(ErrorMessage = "Please Enter Payment_Method_URL")]
        public string Payment_Method_URL { get; set; }


        //[Required(ErrorMessage = "Please Enter Licences_URL")]
        public string Licences_URL { get; set; }



        //[Required(ErrorMessage = "Please Enter Insurance_URL")]
        public string Insurance_URL { get; set; }


        //[Required(ErrorMessage = "Please Enter Insurance_URL")]
        public string Certificates_URL { get; set; }



        //[Required(ErrorMessage = "Please Enter Pricing")]
        public string Pricing { get; set; }


        //[Required(ErrorMessage = "Please Enter Contract_Based")]
        public string Contract_Based { get; set; }


        //[Required(ErrorMessage = "Please Enter Warranty")]
        public string Warranty { get; set; }


        public int BusinessCategoryId { get; set; }
        public IEnumerable<SelectListItem> BusinessCategoryList { get; set; }

    }

}