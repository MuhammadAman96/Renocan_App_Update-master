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

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Company_Search company_Search)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    SqlParameter[] parameters =
                 {      new SqlParameter("@company_Name", SqlDbType.NVarChar) { Value =company_Search.CompanyName },
                        new SqlParameter("@location_Name", SqlDbType.NVarChar) { Value = company_Search.Location}


                 };

                    DataSet ds = DataAccess.GetDataSet(AppConfigurations.ConnectionString, "Search_Company_Main", parameters);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["CompanyName"].ToString()))
                        {

                            return RedirectToAction("Company_search_list", "Home");
                        }
                        else
                        {

                          //  TempData["msg"] = "<script>alert('Not Found');</script>";
                        }

                    }
                    else
                    {

                       // TempData["msg"] = "<script>alert('Not Found');</script>";
                        company_Search.IsError = true;
                        company_Search.ErrorMessage = Constants.ErrorMesssage;
                    }

                }
                return View(company_Search);
            }
            catch (Exception)
            {
                return View(company_Search);
            }
        }

        public ActionResult Company_search_list()
        {
            return View();
        }



        [HttpGet]
        public ActionResult getCompanyList(string cat, string loc)
        {


            return View();
        }


        public DataTable GetCompanyList(string cat, string loc)
        {
            try
            {
                SqlParameter[] parameters =
               {
                new SqlParameter("@category_Name",SqlDbType.VarChar){Value= cat },
                new SqlParameter("@location_Name",SqlDbType.VarChar){Value= loc }

               };

                return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "Select_CompanyList", parameters);
            }
            catch (Exception ex)
            {
                //LogError(ex);
                return null;
            }
        }



        public ActionResult _Company_list(string CategoryName, string CityName)
        {
            CompaniesSearchVM objCompanyResponseModel = new CompaniesSearchVM();
            DataTable datatable = GetCompanyList(CategoryName, CityName);
            objCompanyResponseModel.CompanyList = EnumerableExtension.ToList<CompaniesSearch>(datatable);

            return PartialView(objCompanyResponseModel);
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
            catch (Exception)
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
            try
            {
                List<SelectListItem> BusinessCategoryList = GetBusinessCategoryList();
                registrationCompany.BusinessCategoryList = BusinessCategoryList;

                if (ModelState.IsValid)
                {
                    SqlParameter[] parameters =
                 {      new SqlParameter("@Company_Name", SqlDbType.NVarChar) { Value = registrationCompany.CompanyName},
                    new SqlParameter("@Owner_First_Name", SqlDbType.NVarChar) { Value = registrationCompany.Owner_First_Name},
                      new SqlParameter("@Owner_Last_Name",SqlDbType.NVarChar){Value=registrationCompany.Owner_Last_Name},
                      new SqlParameter("@Category_ID",SqlDbType.Int){Value=registrationCompany.BusinessCategoryId},
                    new SqlParameter("@PostalCode",SqlDbType.NVarChar){Value=registrationCompany.PostalCode},
                      new SqlParameter("@Email", SqlDbType.NVarChar) { Value = registrationCompany.Email },
                       new SqlParameter("@Create_Password",SqlDbType.NVarChar){Value=registrationCompany.Create_Password},
                       new SqlParameter("@PhoneNumber",SqlDbType.NVarChar){Value=registrationCompany.PhoneNumber},
                      new SqlParameter("@UserIP",SqlDbType.NVarChar){Value= Constants.GetUserIP()

                      }
               };

                    DataSet ds = DataAccess.GetDataSet(AppConfigurations.ConnectionString, "Insert_Update_Company_Registration", parameters);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Status"].ToString() == "inserted")
                        {
                            Session["CompanyId"] = ds.Tables[0].Rows[0]["CompanyID"];
                            return RedirectToAction("Listing", "Business_Home");
                        }
                        else if (ds.Tables[0].Rows[0]["Status"].ToString() == "already exist")
                        {

                            ModelState.AddModelError("Email", "Email already registered.");
                        }

                    }
                    else
                    {
                        registrationCompany.IsError = true;
                        registrationCompany.ErrorMessage = Constants.ErrorMesssage;
                    }

                }
                return View(registrationCompany);
            }
            catch (Exception ex)
            {
                return View(registrationCompany);
            }
        }


        public ActionResult Get_a_Quote()
        {

            return View();

        }

 

    }
}