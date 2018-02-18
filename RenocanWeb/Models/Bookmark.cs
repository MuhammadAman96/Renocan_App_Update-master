using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class Bookmark
    {
        public int Bookmark_ID { get; set; }
        public Nullable<int> User_ID { get; set; }
        public Nullable<int> User_TypeId { get; set; }
        public Nullable<int> Company_ID { get; set; }
       
    }
}