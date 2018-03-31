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
            if (Session["ClientId"] != null)
            {
                Review r = new Review();
                r.Review_Rating = 0;
                return View(r);
            }
            return RedirectToAction("Client_login", "ClientAccount");


        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Write_a_review(Review review)
        {
            if (ModelState.IsValid)
            {

                SqlParameter[] parameters =

                {
                    new SqlParameter("@Client_ID", SqlDbType.Int) { Value =Convert.ToInt32(Session["ClientId"])},
                    //new SqlParameter("@IsAggrement", SqlDbType.Bit) { Value = registrationCompany.IsAggrement},
                    //new SqlParameter("@Is_Paid", SqlDbType.Bit) { Value = registrationCompany.Is_Paid},
                      new SqlParameter("@Service_Request_ID",SqlDbType.Int){Value=review.Service_Request_ID},
                    new SqlParameter("@ReviewedBy",SqlDbType.NVarChar){Value=review.ReviewedBy},
                      new SqlParameter("@Service_Review_Status_ID", SqlDbType.Int) { Value = review.Service_Review_Status_ID },
                       new SqlParameter("@Review_Title",SqlDbType.NVarChar){Value=review.Review_Title},
                      new SqlParameter("@Approximate_Cost",SqlDbType.NVarChar){Value= review.Approximate_Cost},
                       new SqlParameter("@Review_Rating", SqlDbType.NVarChar) { Value = review.Review_Rating},
                      new SqlParameter("@Review_Details",SqlDbType.NVarChar){Value=review.Review_Details},
                      new SqlParameter("@IsAnonymous",SqlDbType.Bit){Value=review.IsAnonymous},
                    new SqlParameter("@UserIP",SqlDbType.NVarChar){Value= Constants.GetUserIP()}
                      

                         };

                if (DataAccess.ExecuteNonQuery(AppConfigurations.ConnectionString, "Insert_Update_WriteAReview", parameters))
                    return RedirectToAction("Client_activity", "ClientAccount");
                else
                {
                    review.IsError = true;
                    review.ErrorMessage = Constants.ErrorMesssage;
                }

            }
            return View(review);
        }






        public ActionResult Client_login()
        {
            return View();

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


        [HttpGet]
        public ActionResult Client_Information()
        {

            var client = new Client_Signup();
            client.Client_ID = Convert.ToInt32(Session["ClientId"]);
            DataTable dt = GetClientById(client.Client_ID);
            if (dt != null && dt.Rows.Count > 0)
            {
                client.First_Name = dt.Rows[0]["First_Name"].ToString();
                client.Last_Name = dt.Rows[0]["Last_Name"].ToString();
                client.City = dt.Rows[0]["City"].ToString();
                client.State = dt.Rows[0]["State"].ToString();
                client.Email = dt.Rows[0]["Email"].ToString();
                client.Phone = dt.Rows[0]["Phone"].ToString();
                client.IsNewsletter = Convert.ToBoolean(dt.Rows[0]["IsNewsletter"]);
            }

            return View(client);
        }


        public DataTable GetClientById(int Client_ID)
        {
            try
            {
                SqlParameter[] parameters =
               {
                new SqlParameter("@Client_ID",SqlDbType.Int){Value= Client_ID }

               };

                return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "SelectClientInfoById", parameters);
            }
            catch (Exception ex)
            {
                //LogError(ex);
                return null;
            }
        }





        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Client_Information(Client_Signup client_Sign_up)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    SqlParameter[] parameters =
                       {
                        new SqlParameter("@Client_ID", SqlDbType.Int) { Value =Convert.ToInt32(Session["ClientId"])},
                        new SqlParameter("@First_Name", SqlDbType.NVarChar) { Value = client_Sign_up.First_Name},
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



    }
}