using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace RenocanWeb.Common
{
    public static class AppConfigurations
    {

        public static string ConnectionString
        {

            get
            {
                return ConfigurationManager.ConnectionStrings["ReconanDb"].ToString();
            }
        }
    }
}