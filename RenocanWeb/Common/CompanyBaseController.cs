using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RenocanWeb.Common
{
    public class CompanyBaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            //if (Session["CompanyId"] == null && actionName != "Business_login" && actionName != "BusinessSignUp")
            //{

            //    filterContext.Result = new RedirectResult("~/Business_Home/Business_login");
            //}
            //else
            //    return;
        }
    }
}