using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class Scoreboard : Message
    {
        public int Scoreboard_ID { get; set; }
        public Nullable<int> Visitor_ID { get; set; }
        public string Visitor_Name { get; set; }
        public byte[] Visitor_Ip { get; set; }
        public string Leads { get; set; }
        public Nullable<int> Company_ID { get; set; }

    }
}