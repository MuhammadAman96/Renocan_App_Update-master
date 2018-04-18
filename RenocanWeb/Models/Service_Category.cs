using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class Service_Category : Message
    {
        public int Category_ID { get; set; }
        public string CategoryName { get; set; }
        
    }
    public class CategoriesSearchVM : Message
    {
        public CategoriesSearchVM()
        {
            CategoryList = new List<Service_Category>();
        }
        public List<Service_Category> CategoryList { get; set; }

    }
}