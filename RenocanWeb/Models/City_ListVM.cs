using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class City_List
    {
        public int Client_ID { get; set; }
        public string Location { get; set; }
        public bool IsSelected { get; set; }
    }
    public class City_ListVM : Message
    {
        public City_ListVM()
        {
            CityList = new List<City_List>();
        }
        public List<City_List> CityList { get; set; }

    }
}