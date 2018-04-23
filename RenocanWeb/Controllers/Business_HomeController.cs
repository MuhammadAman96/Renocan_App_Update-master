using CaptchaMvc.HtmlHelpers;
using Newtonsoft.Json;
using RenocanCommon;
using RenocanWeb.Common;
using RenocanWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Configuration;
namespace RenocanWeb.Controllers
{
    public class Business_HomeController : CompanyBaseController
    {
        // GET: Business_Home
        public ActionResult Index()
        {
            return View();
        }


        //
        public ActionResult Listing()
        {

            if (Session["CompanyId"] != null)
            {
                var company = new RegistrationCompanyListing();
                company.Company_ID = Convert.ToInt32(Session["CompanyId"]);
                DataTable dt = GetCompanyById(company.Company_ID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    company.Website_Add = dt.Rows[0]["Website_Add"].ToString();
                    company.Profile_Information = dt.Rows[0]["Profile_Information"].ToString();
                    company.Products = dt.Rows[0]["Products"].ToString();
                    company.Services = dt.Rows[0]["Services"].ToString();
                    company.Brands = dt.Rows[0]["Brands"].ToString();
                    company.Specialities = dt.Rows[0]["Specialities"].ToString();
                    company.Year_Established = dt.Rows[0]["Year_Established"].ToString();
                    company.Return_Policy_URL = dt.Rows[0]["Return_Policy_URL"].ToString();
                    company.Payment_Method_URL = dt.Rows[0]["Payment_Method_URL"].ToString();
                    company.Licences_URL = dt.Rows[0]["Licences_URL"].ToString();
                    company.Certificates_URL = dt.Rows[0]["Certificates_URL"].ToString();
                    company.Insurance_URL = dt.Rows[0]["Insurance_URL"].ToString();
                    company.Pricing = dt.Rows[0]["Pricing"].ToString();
                    company.Contract_Based = dt.Rows[0]["Contract_Based"].ToString();
                    company.Warranty = dt.Rows[0]["Warranty"].ToString();
                    company.Image_Name = !string.IsNullOrEmpty(dt.Rows[0]["Image_Name"].ToString()) ? dt.Rows[0]["Image_Name"].ToString() : "../"+ ConfigurationManager.AppSettings["ClientProfileImageVD"].ToString() + "Default.jpg";
                    company.CompanyName= dt.Rows[0]["CompanyName"].ToString();
                    company.PostalCode= dt.Rows[0]["PostalCode"].ToString();
                    

                }

                return View(company);

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

        //
        public DataTable GetCompanyById(int Company_ID)
        {
            try
            {
                SqlParameter[] parameters =
               {
                new SqlParameter("@Company_ID",SqlDbType.Int){Value= Company_ID }

               };

                return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "SelectCompanyInfoById", parameters);
            }
            catch (Exception ex)
            {
                //LogError(ex);
                return null;
            }
        }
        //

        public JsonResult ImageUpload(Image_Gallary model)
        {

            var file = model.ImageFile;
            string filepath = string.Empty;
            if (file != null)
            {

                var fileName = Path.GetFileName(file.FileName);
                var extention = Path.GetExtension(file.FileName);
                var filenamewithoutextension = Path.GetFileNameWithoutExtension(file.FileName);
                filepath = ConfigurationManager.AppSettings["ClientProfileImageVD"] + Guid.NewGuid().ToString() + extention;
                file.SaveAs(Server.MapPath(filepath));

                SqlParameter[] parameters =
              {

                  new SqlParameter("@ClientId", SqlDbType.Int) { Value = Convert.ToInt32(Session["CompanyId"])  },
                  new SqlParameter("@Image_Name", SqlDbType.VarChar) { Value = filepath  },
                  new SqlParameter("@Image_Type_ID", SqlDbType.VarChar) { Value =1  },
                  new SqlParameter("@User_Typeid", SqlDbType.VarChar) { Value = 1 },
                 new SqlParameter("@UserIP",SqlDbType.NVarChar){Value= Constants.GetUserIP() }
              };
                DataAccess.GetDataTable(AppConfigurations.ConnectionString, "Insert_Update_Image", parameters);

            }

            return Json(filepath, JsonRequestBehavior.AllowGet);

        }

        //
        public ActionResult Media()
        {
            if (Session["CompanyId"] != null)
            {
                var company = new RegistrationCompanyListing();
                company.Company_ID = Convert.ToInt32(Session["CompanyId"]);

                DataTable dt = GetCompanyById(company.Company_ID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    company.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                    company.PostalCode = dt.Rows[0]["PostalCode"].ToString();
                    company.Image_Name = !string.IsNullOrEmpty(dt.Rows[0]["Image_Name"].ToString()) ? dt.Rows[0]["Image_Name"].ToString() : "../" + ConfigurationManager.AppSettings["ClientProfileImageVD"].ToString() + "Default.jpg";

                }

                return View(company);
            }
            return RedirectToAction("Business_login", "Business_Home");
        }

        //
        public ActionResult Reviews()
        {
            if (Session["CompanyId"] != null)
            {
                var company = new RegistrationCompanyListing();
                company.Company_ID = Convert.ToInt32(Session["CompanyId"]);

                DataTable dt = GetCompanyById(company.Company_ID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    company.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                    company.PostalCode = dt.Rows[0]["PostalCode"].ToString();
                    company.Image_Name = !string.IsNullOrEmpty(dt.Rows[0]["Image_Name"].ToString()) ? dt.Rows[0]["Image_Name"].ToString() : "../" + ConfigurationManager.AppSettings["ClientProfileImageVD"].ToString() + "Default.jpg";

                }

                return View(company);
            }
            return RedirectToAction("Business_login", "Business_Home");
        }

        [HttpGet]
        public ActionResult getReviewList()
        {


            return View();
        }

        public DataTable GetReviewList()
        {
            try
            {

                SqlParameter[] parameters =

                {
                    new SqlParameter("@companyId", SqlDbType.Int) { Value =Convert.ToInt32(Session["CompanyId"]) }
                    };


                return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "Select_Reviews", parameters);

            }
            catch (Exception ex)
            {
                //LogError(ex);
                return null;
            }
        }

        public ActionResult _Review_list()
        {
            ReviewListVM objCompanyResponseModel = new ReviewListVM();
            DataTable datatable = GetReviewList();
            objCompanyResponseModel.Reviewlist = EnumerableExtension.ToList<ReviewList>(datatable);

            return PartialView(objCompanyResponseModel);
        }

        //
        public ActionResult Scoreboard()
        {
            if (Session["CompanyId"] != null)
            {
                var company = new RegistrationCompanyListing();
                company.Company_ID = Convert.ToInt32(Session["CompanyId"]);

                DataTable dt = GetCompanyById(company.Company_ID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    company.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                    company.PostalCode = dt.Rows[0]["PostalCode"].ToString();
                    company.Image_Name = !string.IsNullOrEmpty(dt.Rows[0]["Image_Name"].ToString()) ? dt.Rows[0]["Image_Name"].ToString() : "../" + ConfigurationManager.AppSettings["ClientProfileImageVD"].ToString() + "Default.jpg";

                }

                return View(company);
            }
            return RedirectToAction("Business_login", "Business_Home");

        }
        //
        public ActionResult toolkit()
        {
            if (Session["CompanyId"] != null)
            {
                var company = new RegistrationCompanyListing();
                company.Company_ID = Convert.ToInt32(Session["CompanyId"]);

                DataTable dt = GetCompanyById(company.Company_ID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    company.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                    company.PostalCode = dt.Rows[0]["PostalCode"].ToString();
                    company.Image_Name = !string.IsNullOrEmpty(dt.Rows[0]["Image_Name"].ToString()) ? dt.Rows[0]["Image_Name"].ToString() : "../" + ConfigurationManager.AppSettings["ClientProfileImageVD"].ToString() + "Default.jpg";

                }

                return View(company);
            }
            return RedirectToAction("Business_login", "Business_Home");

        }


        //      
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
                            return RedirectToAction("Activity", "Business_Home");
                        }
                        else
                        {

                            ModelState.AddModelError("Email", "Incorrect Email or Password");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("Email", "Incorrect Email or Password");
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

        //           
        public ActionResult LogOut()
        {
            //  FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Home");
        }

        //  
        public ActionResult Business_city()
        {
            return View();
        }
        //

        public ActionResult Business_new_password_()
        {
            return View();
        }

        //
        public ActionResult Client_job_request()
        {
            return View();

        }

        //
        public ActionResult Client_job_request_detail()
        {
            return View();
        }

        // 
        public ActionResult Browse_category()
        {
            return View();
        }

        [HttpGet]
        public ActionResult getCategoryList(string cat)
        {
            return View();
        }

        public DataTable GetCategoryList(string cat)
        {
            try
            {
                SqlParameter[] parameters =
               {
                new SqlParameter("@category_Name",SqlDbType.VarChar){Value= cat }
               };

                return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "Select_CategoryList", parameters);
            }
            catch (Exception ex)
            {
                //LogError(ex);
                return null;
            }
        }

        public ActionResult _Categories(string CategoryLetter)
        {
            CategoriesSearchVM objCompanyResponseModel = new CategoriesSearchVM();
            DataTable datatable = GetCategoryList(CategoryLetter);
            objCompanyResponseModel.CategoryList = EnumerableExtension.ToList<Service_Category>(datatable);

            return PartialView(objCompanyResponseModel);
        }

        //comapny search
        public ActionResult Company_search()

        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Company_search(Company_Search company_Search)
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

                            TempData["msg"] = "<script>alert('Not Found');</script>";
                        }

                    }
                    else
                    {

                        TempData["msg"] = "<script>alert('Not Found');</script>";
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
        public ActionResult getCompanyList()
        {


            return View();
        }

        public DataTable GetCompanyList()
        {
            try
            {
                SqlParameter[] parameters =
               {
                new SqlParameter("@company_Id",SqlDbType.VarChar){Value =Convert.ToInt32(Session["CompanyId"]) },


               };

                return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "Select_CompanyList", parameters);
            }
            catch (Exception ex)
            {
                //LogError(ex);
                return null;
            }
        }

        public ActionResult _Company_list()
        {
            CompaniesSearchVM objCompanyResponseModel = new CompaniesSearchVM();
            DataTable datatable = GetCompanyList();
            objCompanyResponseModel.CompanyList = EnumerableExtension.ToList<CompaniesSearch>(datatable);

            return PartialView(objCompanyResponseModel);
        }



        //

        public ActionResult Company_profile()
        {
            return View();
        }

        public ActionResult _Review_Company_Profile_list()
        {
            ReviewListVM objCompanyResponseModel = new ReviewListVM();
            DataTable datatable = GetReviewList();
            objCompanyResponseModel.Reviewlist = EnumerableExtension.ToList<ReviewList>(datatable);

            return PartialView(objCompanyResponseModel);
        }

        public ActionResult _Company_profile_list()
        {
            CompaniesSearchVM objCompanyResponseModel = new CompaniesSearchVM();
            DataTable datatable = GetCompanyList();
            objCompanyResponseModel.CompanyList = EnumerableExtension.ToList<CompaniesSearch>(datatable);

            return PartialView(objCompanyResponseModel);
        }


        public ActionResult getProfile_Info()
        {


            return View();
        }


        public DataTable GetProfile_Info()
        {
            try
            {
                SqlParameter[] parameters =
               {
                new SqlParameter("@companyId",SqlDbType.VarChar){Value=Convert.ToInt32(Session["CompanyId"])}

               };

                return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "Select_CompanyInfo", parameters);
            }
            catch (Exception ex)
            {
                //LogError(ex);
                return null;
            }
        }



        public ActionResult _Info_Company_Profile()
        {
            CompanieslistingVM objCompanyResponseModel = new CompanieslistingVM();
            DataTable datatable = GetProfile_Info();
            objCompanyResponseModel.CompanyListing = EnumerableExtension.ToList<Profile_Info>(datatable);
            return PartialView(objCompanyResponseModel);

        }

        //

        public ActionResult Activity()
        {
            if (Session["CompanyId"] != null)
            {
                var company = new RegistrationCompanyListing();
                company.Company_ID = Convert.ToInt32(Session["CompanyId"]);

                DataTable dt = GetCompanyById(company.Company_ID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    company.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                    company.PostalCode = dt.Rows[0]["PostalCode"].ToString();
                    company.Image_Name = !string.IsNullOrEmpty(dt.Rows[0]["Image_Name"].ToString()) ? dt.Rows[0]["Image_Name"].ToString() : "../" + ConfigurationManager.AppSettings["ClientProfileImageVD"].ToString() + "Default.jpg";

                }

                return View(company);
            }
            return RedirectToAction("Business_login", "Business_Home");
        }
        [HttpGet]
        public ActionResult getCompanyActivityList()
        {

            return View();
        }
        public DataTable GetCompanyActivityList()
        {
            try
            {
                SqlParameter[] parameters =
               {
                  new SqlParameter("@companyId", SqlDbType.Int) { Value =Convert.ToInt32(Session["CompanyId"])}
               };

                return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "Select_CompanyActivity", parameters);
            }
            catch (Exception ex)
            {
                //LogError(ex);
                return null;
            }
        }



        public ActionResult _CompanyActivityList()
        {
            Company_ActivityVM objCompanyResponseModel = new Company_ActivityVM();
            DataTable datatable = GetCompanyActivityList();
            objCompanyResponseModel.ComActivityList = EnumerableExtension.ToList<Company_Activity>(datatable);
            return PartialView(objCompanyResponseModel);
        }

        //
        public ActionResult Business_forgot_password()
        {
            return View();

        }
        //

        public ActionResult CompanyPasswordRecovery()
        {
            PasswordRecovery passwordRecovery = new PasswordRecovery();
            return View(passwordRecovery);
        }
        //
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult CompanyPasswordRecovery(PasswordRecovery passwordRecovery)
        {
            Email service = new Email();

            if (ModelState.IsValid)
            {
                if (this.IsCaptchaValid("Validate your captcha"))
                {
                    Customer customerService = new Customer();
                    string result = customerService.CompanyPasswordRecovery(passwordRecovery.Email);
                    if (!string.IsNullOrEmpty(result))
                    {
                        service.CompanySendEmail(result, passwordRecovery.Email);
                        passwordRecovery.Message = "Password Recovery link has been send to your Email ";
                    }
                    else
                    {
                        passwordRecovery.Message = "Incorrect provided Email";
                    }
                }
                else
                    passwordRecovery.Message = "Wrong Captcha try again";
            }

            return View(passwordRecovery);
        }
        //
        public ActionResult CompanyPasswordRecoveryConfirm(string token, string email)
        {
            PasswordRecoveryConfirm passwordRecoveryConfirm = new PasswordRecoveryConfirm();
            Customer customerService = new Customer();


            passwordRecoveryConfirm.DisablePasswordChanging = false;
            DataTable objDt = customerService.CompanyPasswordRecoveryCheck(token, email);
            if (objDt != null && objDt.Rows.Count > 0)
            {
                if (Convert.ToDateTime(objDt.Rows[0]["PasswordRecoverExpiry"]) < DateTime.Now)
                {
                    passwordRecoveryConfirm.Message = "Password Recovery Link has been Expired";
                    passwordRecoveryConfirm.DisablePasswordChanging = true;
                }
            }
            else
            {
                passwordRecoveryConfirm.Message = "Incorrect Recovery Url";
                passwordRecoveryConfirm.DisablePasswordChanging = true;
            }

            return View(passwordRecoveryConfirm);
        }
        //
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult CompanyPasswordRecoveryConfirm(string token, string email, PasswordRecoveryConfirm passwordRecoveryConfirm)
        {
            if (ModelState.IsValid)
            {
                Customer customerService = new Customer();
                passwordRecoveryConfirm.DisablePasswordChanging = false;
                if (customerService.CompanyPasswordReset(email, passwordRecoveryConfirm.Password))
                {
                    passwordRecoveryConfirm.Message = "Successfully ..! Password has been changed";
                    passwordRecoveryConfirm.DisablePasswordChanging = true;
                }
            }
            return View(passwordRecoveryConfirm);
        }
        //
        [HttpGet]
        public ActionResult CompanyChangePassword()
        {
            if (Session["CompanyId"] == null)
            {

                return RedirectToAction("Business_login", "Business_Home", new { returnUrl = Request.RawUrl });
            }
            ChangePasswordModel cpm = new ChangePasswordModel();
            return View(cpm);
        }
        //
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult CompanyChangePassword(ChangePasswordModel requestModel)
        {
            if (Session["CompanyId"] == null)
            {
                return RedirectToAction("Business_login", "Business_Home", new { returnUrl = Request.RawUrl });
            }
            if (ModelState.IsValid)
            {
                Customer customerService = new Customer();
                DataTable dtb = customerService.CompanyChangePassword(Convert.ToInt32(Session["CompanyId"]), requestModel.CurrentPassword,
                                   requestModel.NewPassword);

                if (dtb != null && dtb.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtb.Rows[0]["IsValidPassword"]))
                    {
                        requestModel.SuccessMessage = "Successfully ..! Password has been changed";
                    }

                    else
                    {
                        ModelState.AddModelError("", "ChangePassword");
                    }
                }
            }

            return View(requestModel);
        }





        //




    }
}