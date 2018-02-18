using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RenocanWeb.Models;
using RenocanCommon;

using System.Configuration;
using System.Data;

namespace RenocanWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Company_search_list()
        {
            return View();
        }


        public ActionResult BusinessSignUp()
        {
            var RegistrationCompany = new RegistrationCompany();
            List<SelectListItem> BusinessCategoryList = GetBusinessCategoryList();
            RegistrationCompany.BusinessCategoryList = BusinessCategoryList;            
            return View(RegistrationCompany);
        }

        public List<SelectListItem> GetBusinessCategoryList()
        {
            List<SelectListItem> BusinessCategoryList = new List<SelectListItem>();
            try
            {
                DataTable dt = DataAccess.GetDataTable(ConfigurationManager.ConnectionStrings[Constants.RenocanWebConnectionString].ToString(), "Select_BusinessCategory", null);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        BusinessCategoryList.Add(new SelectListItem() { Value = dt.Rows[i]["Category_ID"].ToString(), Text = dt.Rows[i]["CategoryName"].ToString() });
                    }
                }
                return BusinessCategoryList;
            }
            catch (Exception )
            {
                //LogError(ex);
                return null;
            }
        }





    }
}