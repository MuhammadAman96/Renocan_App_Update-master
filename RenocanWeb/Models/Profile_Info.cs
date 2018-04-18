using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class Profile_Info:Message
    {
        
       public string CompanyName { get; set; }

        public string CategoryName { get; set; }


        //[Required(ErrorMessage = "Please Enter Website_Add")]
        public string Website_Add { get; set; }


        //[Required(ErrorMessage = "Please Enter Bussiness_Description")]
        public string Bussiness_Description { get; set; }


        //[Required(ErrorMessage = "Please Enter Profile_Information")]
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
    }
    public class CompanieslistingVM : Message
    {
        public CompanieslistingVM()
        {
            CompanyListing = new List<Profile_Info>();
        }
        public List<Profile_Info> CompanyListing { get; set; }

    }

}