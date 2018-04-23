using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security.Cryptography;

using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace RenocanCommon
{
    //public class Helper
    //{
    //    public int getUserIDFromCookie()
    //    {
    //        int UserCode = 0;
    //        if (HttpContext.Current.Request.Cookies["user%5Fid"] != null)
    //        {
    //            UserCode = Convert.ToInt32(HttpContext.Current.Request.Cookies["user%5Fid"].Value);

    //            UserCode = UserCode / 854;
    //        }

    //        return UserCode;
    //    }

    //    public static bool SetCookie(string name, string value, double expiryMinutes)
    //    {
    //        try
    //        {
    //            HttpCookie cookie = new HttpCookie(name);
    //            cookie.Value = Cryptography.Encryption(value);
    //            cookie.Expires = DateTime.Now.AddMinutes(expiryMinutes);
    //            HttpContext.Current.Response.Cookies.Add(cookie);
    //            return true;
    //        }
    //        catch (Exception)
    //        {
    //            return false;
    //        }
    //    }

    //    public static string GetCookie(string name, bool isEncrypted = false)
    //    {
    //        HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
    //        if (cookie != null)
    //            if (isEncrypted)
    //                return Cryptography.Decryption(cookie.Value);
    //            else return cookie.Value;
    //        return null;

    //    }

    //    public static void ExpireCookie(string name)
    //    {
    //        if (HttpContext.Current.Request.Cookies[name] != null)
    //        {
    //            var cookie = new HttpCookie(name);
    //            cookie.Expires = DateTime.Now.AddDays(-1);
    //            HttpContext.Current.Response.Cookies.Add(cookie);
    //        }
    //        //HttpContext.Current.Response.Cookies.Remove(name);

    //    }
    //    public static void ExpireAllCookies()
    //    {
    //        string[] myCookies = HttpContext.Current.Request.Cookies.AllKeys;
    //        foreach (string cookie in myCookies)
    //        {
    //            HttpContext.Current.Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
    //        }
    //        //HttpContext.Current.Request.Cookies.Clear();
    //    }


    //    public static string GetRequestIP
    //    {
    //        get { return HttpContext.Current.Request.UserHostAddress; }
    //    }

    //}
}
