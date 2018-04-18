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
    

        public string CompanyName { get; set; }


        [AllowHtml]
       
        [RegularExpression(@"^([a-zA-Z\s'-]{3,50})$", ErrorMessage = "Type Valid Name")]
        public string Location { get; set; }
    }

    public class Company : Message
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }
        
    }

    public class LocationS : Message
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }

    }




}