using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RenocanCommon
{
    public class Helper
    {
        public int getUserIDFromCookie()
        {
            int UserCode = 0;
            if (HttpContext.Current.Request.Cookies["user%5Fid"] != null)
            {
                UserCode = Convert.ToInt32(HttpContext.Current.Request.Cookies["user%5Fid"].Value);

                UserCode = UserCode / 854;
            }

            return UserCode;
        }



    }
}
