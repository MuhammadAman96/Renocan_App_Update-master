using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class Service_Request : Message
    {
        public int Service_Request_ID { get; set; }
        public Nullable<int> User_ID { get; set; }
        public Nullable<int> User_TypeId { get; set; }
        public Nullable<int> Company_Category_ID { get; set; }
        public int Service_Request_Status_ID { get; set; }
        public Nullable<System.DateTime> Request_Date { get; set; }
        public string Request_Reply { get; set; }
        public string Problem_description { get; set; }
        public string Kind_of_Location { get; set; }
        public string Postal_Code { get; set; }
     
    }
}