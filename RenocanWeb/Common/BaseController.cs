using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RenocanWeb.Common
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (Session["ClientId"] == null)
            {
                filterContext.Result = new RedirectResult("~/ClientAccount/Client_login");
            }
            else
                return;
        }            

    
    }
}
