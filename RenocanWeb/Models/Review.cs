using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class Review : Message
    {
        public int Review_ID { get; set; }
        public int? Service_Request_ID { get; set; }
        public string ReviewedBy { get; set; }
        public Nullable<System.DateTime> ReviewedDate { get; set; }
        public Nullable<int> Service_Review_Status_ID { get; set; }
        public string Review_Title { get; set; }
        public string Approximate_Cost { get; set; }
        public string Review_Details { get; set; }
        public string Location { get; set; }
        public string PostalCode { get; set; }
        public Nullable<int> Review_Rating { get; set; }
        public Nullable<System.TimeSpan> Review_Time { get; set; }
        public bool IsAnonymous { get; set; }
     
    }
}