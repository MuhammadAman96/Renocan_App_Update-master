using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class Company_Service_Location : Message 
    {
        public int Company_Service_Location_Id { get; set; }
        public Nullable<int> Company_ID { get; set; }
        public Nullable<int> Location_ID { get; set; }
       
    }
}