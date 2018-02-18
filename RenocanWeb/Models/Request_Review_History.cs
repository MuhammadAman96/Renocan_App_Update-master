using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class Request_Review_History
    {
        public int Request_Review_History_ID { get; set; }
        public Nullable<int> Review_ID { get; set; }
        public string Job_Description { get; set; }
        public string Client_Phone { get; set; }
        public string Email { get; set; }
        public Nullable<bool> IsEmailSent { get; set; }
        public Nullable<bool> IsSmsSent { get; set; }
        
    }
}