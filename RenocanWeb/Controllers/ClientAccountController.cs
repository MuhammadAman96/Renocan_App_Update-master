using RenocanCommon;
using RenocanWeb.Common;
using RenocanWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RenocanWeb.Controllers
{
    public class ClientAccountController : Controller
    {
        // GET: ClientAccount
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Client_Sign_up()
        {
            var Client_Signup = new Client_Signup();

            return View(Client_Signup);
        }


        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Client_Sign_up(Client_Signup client_Sign_up)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    SqlParameter[] parameters =
                       {  new SqlParameter("@First_Name", SqlDbType.NVarChar) { Value = client_Sign_up.First_Name},
                      new SqlParameter("@Last_Name",SqlDbType.NVarChar){Value=client_Sign_up.Last_Name},
                      new SqlParameter("@City", SqlDbType.NVarChar) { Value = client_Sign_up.City },
                       new SqlParameter("@State",SqlDbType.NVarChar){Value=client_Sign_up.State},
                      new SqlParameter("@Email", SqlDbType.NVarChar) { Value = client_Sign_up.Email },
                       new SqlParameter("@Create_Password",SqlDbType.NVarChar){Value=client_Sign_up.Create_Password},
                       new SqlParameter("@Phone",SqlDbType.NVarChar){Value=client_Sign_up.Phone},
                      new SqlParameter("@IsNewsletter", SqlDbType.Bit) { Value = client_Sign_up.IsNewsletter },
                      new SqlParameter("@UserIP",SqlDbType.NVarChar){Value= Constants.GetUserIP() }
               };

                    DataSet ds = DataAccess.GetDataSet(AppConfigurations.ConnectionString, "Insert_Update_Client_Registration", parameters);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Status"].ToString() == "inserted")
                        {
                            Session["ClientId"] = ds.Tables[0].Rows[0]["ClientID"];
                            return RedirectToAction("Client_activity", "ClientAccount");
                        }
                        else if (ds.Tables[0].Rows[0]["Status"].ToString() == "already exist")
                        {

                            ModelState.AddModelError("Email", "Email already registered.");
                        }

                    }

                    else
                    {
                        client_Sign_up.IsError = true;
                        client_Sign_up.ErrorMessage = Constants.ErrorMesssage;
                    }

                }
                return View(client_Sign_up);
            }
            catch (Exception ex)
            {
                return View(client_Sign_up);
            }
        }


        public ActionResult LogOut()
        {
          //  FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Client_login(Login login)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    SqlParameter[] parameters =
                 {      new SqlParameter("@Email", SqlDbType.NVarChar) { Value =login.Email },
                        new SqlParameter("@Password", SqlDbType.NVarChar) { Value = login.Password}


                 };

                    DataSet ds = DataAccess.GetDataSet(AppConfigurations.ConnectionString, "Check_ClientLogin", parameters);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Client_ID"].ToString()))
                        {
                            Session["ClientId"] = ds.Tables[0].Rows[0]["Client_ID"];
                            return RedirectToAction("Client_activity", "ClientAccount");
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







        public ActionResult Client_bookmarks()
        {
            return View();

        }


        public ActionResult Client_activity()
        {
            return View();

        }

        public ActionResult Client_review()
        {
            return View();

        }


        public ActionResult Client_forgot_password()
        {
            return View();

        }


        public ActionResult Client_job_request()
        {
            return View();

        }


        public ActionResult Write_a_review()
        {
            return View();

        }

        public ActionResult Client_login()
        {
            return View();

        }


        public ActionResult Client_city()
        {
            return View();
        }


        public ActionResult Client_job_request_detail()
        {
            return View();
        }


        public ActionResult Client_new_password_()
        {
            return View();
        }



        public ActionResult Client_Information()
        {
            return View();
        }





    }
}