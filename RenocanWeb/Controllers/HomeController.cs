using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RenocanWeb.Models;
using RenocanCommon;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using RenocanWeb.Common;

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



        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]      
        public ActionResult BusinessSignUp(RegistrationCompany registrationCompany)
        {
            if (ModelState.IsValid)
            {
                      SqlParameter[] parameters =

                   {new SqlParameter("@Company_Name", SqlDbType.NVarChar) { Value = registrationCompany.CompanyName},
                    new SqlParameter("@Owner_First_Name", SqlDbType.NVarChar) { Value = registrationCompany.Owner_First_Name},
                      new SqlParameter("@Owner_Last_Name",SqlDbType.NVarChar){Value=registrationCompany.Owner_Last_Name},
                      new SqlParameter("@Category_ID",SqlDbType.NVarChar){Value=registrationCompany.BusinessCategoryId},
                    new SqlParameter("@PostalCode",SqlDbType.NVarChar){Value=registrationCompany.PostalCode},
                      new SqlParameter("@Email", SqlDbType.NVarChar) { Value = registrationCompany.Email },
                       new SqlParameter("@Create_Password",SqlDbType.NVarChar){Value=registrationCompany.Create_Password},
                       new SqlParameter("@PhoneNumber",SqlDbType.NVarChar){Value=registrationCompany.PhoneNumber},
                      new SqlParameter("@UserIP",SqlDbType.NVarChar){Value= Constants.GetUserIP()

                      }
               };

                if (DataAccess.ExecuteNonQuery(AppConfigurations.ConnectionString, "Insert_Update_Company_Registration", parameters))
                    return RedirectToAction("BusinessSignUp");
                else
                {
                    registrationCompany.IsError = true;
                    registrationCompany.ErrorMessage = Constants.ErrorMesssage;
                }

            }
            return View(registrationCompany);
        }
















    }
}