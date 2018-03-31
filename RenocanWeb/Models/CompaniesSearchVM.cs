using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class CompaniesSearch 
    {
        public int Company_ID { get; set; }
        public string Location { get; set; }
        public string CompanyName { get; set; }
        public string Logo { get; set; }
        public string Phone { get; set; }
        public string Rating { get; set; }
        public string TotalReviews { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Profile_Information { get; set; }
        public bool IsBookmark { get; set; }

    }
    public class CompaniesSearchVM : Message
    {
        public CompaniesSearchVM()
        {
            CompanyList = new List<CompaniesSearch>();
        }
        public List<CompaniesSearch> CompanyList { get; set; }

    }
}