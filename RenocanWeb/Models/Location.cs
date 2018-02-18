using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class Location : Message
    {
        public int Location_ID { get; set; }
        public string Location_Name { get; set; }
        public string Postal_Code { get; set; }
      
    }
}