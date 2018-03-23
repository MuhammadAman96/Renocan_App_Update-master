using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class Login:Message
    {

        public string Email { get; set; }

        public string Password { get; set; }
    }
}