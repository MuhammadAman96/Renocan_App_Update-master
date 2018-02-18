using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class Client_Signup
    {
        public int Client_ID { get; set; }
        public string Full_Name { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Create_Password { get; set; }
        public string Confirm_Password { get; set; }

        public string Phone { get; set; }
        public string IsNewsletter { get; set; }

    }
}