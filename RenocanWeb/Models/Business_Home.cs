using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class Business_Home : Message
    {
        public int? Activity_ID { get; set; }


        public Nullable<System.DateTime> Activity_Date { get; set; }



        [Required(ErrorMessage = "Please Select Reviews_Commented")]
        public string Reviews_Commented { get; set; }



        [Required(ErrorMessage = "Enter Rating")]
        public Nullable<int> Ratings { get; set; }


        [Required(ErrorMessage = "Please Select Company")]
        public Nullable<int> Company_ID { get; set; }


        [Required(ErrorMessage = "Please Select Company")]
        public Nullable<int> Targeted_Company { get; set; }

    }
}