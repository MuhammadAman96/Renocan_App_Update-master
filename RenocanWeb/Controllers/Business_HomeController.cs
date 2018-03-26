using RenocanCommon;
using RenocanWeb.Common;
using RenocanWeb.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RenocanWeb.Controllers
{
    public class Business_HomeController : CompanyBaseController
    {
        // GET: Business_Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Activity()
        {
            return View();
        }


        public ActionResult Listing()
        {
            if (Session["CompanyId"] != null)
            {
                return View();
            }
            return RedirectToAction("Business_Login", "Business_Home");

        }



        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Listing(RegistrationCompanyListing registrationCompany)
        {
            if (ModelState.IsValid)
            {
               
                    SqlParameter[] parameters =

                    {
                    new SqlParameter("@Company_ID", SqlDbType.Int) { Value =Convert.ToInt32(Session["CompanyId"])},
                    //new SqlParameter("@IsAggrement", SqlDbType.Bit) { Value = registrationCompany.IsAggrement},
                    //new SqlParameter("@Is_Paid", SqlDbType.Bit) { Value = registrationCompany.Is_Paid},
                      new SqlParameter("@Website_Add",SqlDbType.NVarChar){Value=registrationCompany.Website_Add},
                    new SqlParameter("@Profile_Information",SqlDbType.NVarChar){Value=registrationCompany.Profile_Information},
                      new SqlParameter("@Products", SqlDbType.NVarChar) { Value = registrationCompany.Products },                       
                       new SqlParameter("@Services",SqlDbType.NVarChar){Value=registrationCompany.Services},
                      new SqlParameter("@Brands",SqlDbType.NVarChar){Value= registrationCompany.Brands},
                       new SqlParameter("@Specialities", SqlDbType.NVarChar) { Value = registrationCompany.Specialities},
                      new SqlParameter("@Year_Established",SqlDbType.NVarChar){Value=registrationCompany.Year_Established},
                      new SqlParameter("@Return_Policy_URL",SqlDbType.NVarChar){Value=registrationCompany.Return_Policy_URL},
                    new SqlParameter("@Payment_Method_URL",SqlDbType.NVarChar){Value=registrationCompany.Payment_Method_URL},
                      new SqlParameter("@Licences_URL", SqlDbType.NVarChar) { Value = registrationCompany.Licences_URL },
                       new SqlParameter("@Insurance_URL",SqlDbType.NVarChar){Value=registrationCompany.Insurance_URL},
                       new SqlParameter("@Certificates_URL",SqlDbType.NVarChar){Value=registrationCompany.Certificates_URL},
                      new SqlParameter("@Pricing",SqlDbType.NVarChar){Value= registrationCompany.Pricing },
                       new SqlParameter("@Contract_Based",SqlDbType.NVarChar){Value=registrationCompany.Contract_Based},
                      new SqlParameter("@Warranty",SqlDbType.NVarChar){Value= registrationCompany.Warranty},
                      new SqlParameter("@Ip",SqlDbType.NVarChar){Value= Constants.GetUserIP()}

                         };

                    if (DataAccess.ExecuteNonQuery(AppConfigurations.ConnectionString, "Update_Remaining_Company_Registration", parameters))
                        return RedirectToAction("Activity", "Business_Home");
                    else
                    {
                        registrationCompany.IsError = true;
                        registrationCompany.ErrorMessage = Constants.ErrorMesssage;
                    }
                
            }
            return View(registrationCompany);
        }





        public ActionResult Media()
        {
            return View();
        }
        public ActionResult Reviews()
        {
            return View();
        }
        public ActionResult Scoreboard()
        {
            return View();

        }
        public ActionResult toolkit()
        {
            return View();

        }


        public ActionResult Business_forgot_password()
        {
            return View();

        }

        public ActionResult Browse_category()
        {
            return View();
        }





        public ActionResult Business_login()
        {

            return View();

        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Business_login(Login login)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    SqlParameter[] parameters =
                 {      new SqlParameter("@Email", SqlDbType.NVarChar) { Value =login.Email },
                        new SqlParameter("@Password", SqlDbType.NVarChar) { Value = login.Password}


                 };

                    DataSet ds = DataAccess.GetDataSet(AppConfigurations.ConnectionString, "Check_BusinessLogin", parameters);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Company_ID"].ToString()))
                        {
                            Session["CompanyId"] = ds.Tables[0].Rows[0]["Company_ID"];
                            return RedirectToAction("Listing", "Business_Home");
                        }
                        else 
                        {

                            ModelState.AddModelError("Email", "Incorrect Email or Password");
                        }

                    }
                    else
                    {
                        login.IsError = true;
                        login.ErrorMessage = Constants.ErrorMesssage;
                    }

                }
                return View(login);
            }
            catch (Exception)
            {
                return View(login);
            }
        }


        public ActionResult LogOut()
        {
            //  FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Home");
        }




        public ActionResult Business_city()
        {
            return View();
        }
        public ActionResult Company_profile()
        {
            return View();
        }

        public ActionResult Company_search()

        {
            return View();
        }


        public ActionResult Business_new_password_()
        {
            return View();
        }







    }
}