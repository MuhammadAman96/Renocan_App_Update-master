using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RenocanCommon
{
    public static class Constants
    {
        public const string RenocanWebConnectionString = "ReconanDb";


        public static string GetUserIP()
        {
            return HttpContext.Current.Request.UserHostAddress.ToString();
        }

        public  static string ErrorMesssage = "Your request can't be completed at this moment please contact your administrator";

       
        public const string CustomerID = "c_id";
        public const string LandingURL = "landingURL";
        public const string ReferrerURL = "referrerURL";
      
        public static bool IsAjaxRequestAccept
        {
            get
            {
                //Uri url = HttpContext.Current.Request.UrlReferrer;
                //if (url != null)
                //    return AppConfigurations.Host.Contains(url.Host);

                return true;
            }
        }
    }
}
