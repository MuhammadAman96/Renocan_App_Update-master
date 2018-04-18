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
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetCompanies(string search)
        {
            try
            {
                SqlParameter[] parameters =
             {      new SqlParameter("@company_Name", SqlDbType.NVarChar) { Value = search } };
                               
                DataSet ds = DataAccess.GetDataSet(AppConfigurations.ConnectionString, "Autocomplete_Search_Company", parameters);
                var CompanyList = EnumerableExtension.ToList<Company>(ds.Tables[0]);
                return Json(CompanyList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult GetLocations(string search)
        {
            try
            {
                SqlParameter[] parameters =
             {      new SqlParameter("@location_Name", SqlDbType.NVarChar) { Value = search } };

                DataSet ds = DataAccess.GetDataSet(AppConfigurations.ConnectionString, "Autocomplete_Search_Location", parameters);
                var LocationList = EnumerableExtension.ToList<LocationS>(ds.Tables[0]);
                return Json(LocationList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}


