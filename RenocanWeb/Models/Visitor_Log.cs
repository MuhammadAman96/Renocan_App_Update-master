using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class Visitor_Log : Message
    {

        public int User_Log_ID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Time_In { get; set; }
        public Nullable<System.TimeSpan> Time_Out { get; set; }
        public Nullable<int> Company_ID { get; set; }
       
    }
}