using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RenocanWeb.Models
{
    public class Location : Message
    {
        public int Location_ID { get; set; }
        public string Location_Name { get; set; }
        public string Postal_Code { get; set; }
        public IEnumerable<SelectListItem> Ctylist { get; set; }

    }
    public class Locations : Message
    {
        public Locations()
        {
            locationlist = new List<Location>();
        }
        public List<Location> locationlist { get; set; }

    }


}