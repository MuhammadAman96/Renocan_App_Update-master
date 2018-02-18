using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class Image_Gallary : Message
    {
        public int Image_ID { get; set; }
        public string Image_Name { get; set; }
        public string Image_Path { get; set; }
        public Nullable<int> User_ID { get; set; }
        public Nullable<int> Image_Type_ID { get; set; }
        public Nullable<int> User_Typeid { get; set; }
  
    }
}