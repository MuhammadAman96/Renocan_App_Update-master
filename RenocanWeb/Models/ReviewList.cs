using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RenocanWeb.Models
{
    public class ReviewList
    {
        public int Company_ID { get; set; }
        public string CompanyName { get; set; }
        public string Review_Rating { get; set; }
        public string Review_Details { get; set; }
        public string Review_Title { get; set; }
        public string ReviewedDate { get; set; }
        public string PostalCode { get; set; }
        public string Approximate_Cost { get; set; }
        public int Service_Review_Status_ID { get; set; }
        public string ComapanyResponse { get; set; }
        public bool IsAnonymous { get; set; }
        


    }
    public class ReviewListVM : Message
    {
        public ReviewListVM()
        {
            Reviewlist = new List<ReviewList>();
        }
        public List<ReviewList> Reviewlist { get; set; }

    }

}