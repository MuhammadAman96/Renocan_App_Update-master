using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace RenocanWeb.Common
{
    public class Common
    {
        public static string ClientProfileImageVD
        {
            get
            {

                return ConfigurationManager.AppSettings["ClientProfileImageVD"].ToString();
            }
        }
        public static string ClientGalleryImageVD
        {
            get
            {

                return ConfigurationManager.AppSettings["ClientGalleryImageVD"].ToString();
            }
        }
    }
}