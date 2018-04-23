using RenocanCommon;
using RenocanWeb.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RenocanWeb.Models
{
    public class Customer
    {

        //public DataTable CheckLogin(string username, string password, string userIP)
        //{
        //    SqlParameter[] sqlParams = {
        //                new SqlParameter("@Username", username),
        //                new SqlParameter("@Password", password),
        //                new SqlParameter("@UserIP", userIP)};

        //    return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "CA_Select_Login", sqlParams);
        //}

        //public DataTable GetCustomerType()
        //{
        //    return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "Select_CustomerType", null);
        //}
        //public List<SelectListItem> GetCustomerTypeList()
        //{
        //    List<SelectListItem> lstData = new List<SelectListItem>();
        //    foreach (DataRow item in GetCustomerType().Rows)
        //    {
        //        lstData.Add(new SelectListItem()
        //        {
        //            Value = item["CustomerTypeId"].ToString(),
        //            Text = item["CustomerTypeName"].ToString()
        //        });
        //    }
        //    return lstData;
        //}

        //public DataTable AddCustomer(string username, string email, string password, int customerTypeId, string landingUrl, string referrerUrl
        //    , int signupPageId, int signupThroughId, string userAgent, int statusid, string comments)
        //{
        //    SqlParameter[] sqlParams = {
        //        new SqlParameter("@FullName", username),
        //        new SqlParameter("@Email", email),
        //        new SqlParameter("@Password", password),
        //        new SqlParameter("@CustomerTypeId", customerTypeId),
        //        new SqlParameter("@RegistrationIP", HttpContext.Current.Request.UserHostAddress),
        //        new SqlParameter("@LandingUrl", landingUrl),
        //        new SqlParameter("@ReferrerUrl", referrerUrl),
        //        new SqlParameter("@SignupPageId", signupPageId),
        //        new SqlParameter("@SignupThroughId", signupThroughId),
        //        new SqlParameter("@UserAgent", userAgent),
        //        new SqlParameter("@Statusid", statusid),
        //        new SqlParameter("@Comments", comments)
        //                };

        //    return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "CA_Insert_Customer", sqlParams);
        //}

        //public DataTable UpdateCustomer(int customerId, string username, string email, string companyName)
        //{
        //    SqlParameter[] sqlParams = {
        //        new SqlParameter("@CustomerId", customerId),
        //        new SqlParameter("@FullName", username),
        //        new SqlParameter("@Email", email),
        //        new SqlParameter("@CompanyName", companyName)
        //                };

        //    return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "CA_Update_Customer", sqlParams);
        //}

        //public DataTable AddCustomerContact(int customerId, string cellFlag, string cellNo, string phoneNo)
        //{
        //    SqlParameter[] sqlParams = {
        //        new SqlParameter("@CustomerId", customerId),
        //        new SqlParameter("@CellFlag", cellFlag),
        //        new SqlParameter("@CellNo", cellNo),
        //        new SqlParameter("@PhoneNo", phoneNo)
        //                };

        //    return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "CA_Insert_CustomerContact", sqlParams);
        //}
        //public DataTable AddCustomerContact(int customerId, string cellFlag, string cellNo, string phoneNo, string countryFlag, int? portId)
        //{
        //    SqlParameter[] sqlParams = {
        //        new SqlParameter("@CustomerId", customerId),
        //        new SqlParameter("@CellFlag", cellFlag),
        //        new SqlParameter("@CellNo", cellNo),
        //        new SqlParameter("@PhoneNo", phoneNo),
        //        new SqlParameter("@CountryFlag", countryFlag),
        //        new SqlParameter("@PortId", portId)
        //                };

        //    return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "CA_Insert_CustomerContact", sqlParams);
        //}

        //public DataTable AddCustomerAddress(int customerId, string addressId, string name, string email, string countryFlag, int? stateId, string city, string zipCode
        //    , int? portId, string addressLine1, string addressLine2, string phoneNo, string cellFlag)
        //{
        //    SqlParameter[] sqlParams = {
        //        new SqlParameter("@CustomerId", customerId),
        //        new SqlParameter("@AddressId", addressId),
        //        new SqlParameter("@FullName", name),
        //        new SqlParameter("@Email", email),
        //        new SqlParameter("@CountryFlag", countryFlag),
        //        new SqlParameter("@PhoneFlag", cellFlag),
        //        new SqlParameter("@StateId", stateId),
        //        new SqlParameter("@City", city),
        //        new SqlParameter("@ZipCode", zipCode),
        //        new SqlParameter("@PortId", portId),
        //        new SqlParameter("@AddressLine1", addressLine1),
        //        new SqlParameter("@AddressLine2", addressLine2),
        //        new SqlParameter("@PhoneNumber", phoneNo)
        //                };

        //    return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "CA_Insert_Address", sqlParams);
        //}

        //public DataTable AddCustomerOrder(int customerId, int addressId, string stockIds)
        //{
        //    SqlParameter[] sqlParams = {
        //        new SqlParameter("@CustomerId", customerId),
        //        new SqlParameter("@AddressId", addressId),
        //        new SqlParameter("@StockIds", stockIds),
        //        new SqlParameter("@UpdatedIP", Helper.GetRequestIP)
        //                };

        //    return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "CA_Insert_Order", sqlParams);
        //}


        //public DataTable GetCustomerDetail(int customerId)
        //{
        //    SqlParameter[] sqlParams = {
        //                new SqlParameter("CustomerId", customerId)};

        //    return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "CA_Select_CustomerDetail", sqlParams);
        //}

        //public DataTable GetCustomerAddress(int customerId)
        //{
        //    SqlParameter[] sqlParams = {
        //                new SqlParameter("CustomerId", customerId)};

        //    return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "CA_Select_CustomerAddress", sqlParams);
        //}


        //public DataTable DeleteCustomerShippingAddress(int customerId, int addressId)
        //{
        //    SqlParameter[] sqlParams = {
        //                new SqlParameter("@CustomerId", customerId),
        //                new SqlParameter("@AddressId", addressId)               };

        //    return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "CA_Update_InactiveCustomerAddress", sqlParams);
        //}
      


        public string PasswordRecovery(string email)
        {
            string token = Guid.NewGuid().ToString();
            SqlParameter[] sqlParams = {
                new SqlParameter("@Email", email),
                new SqlParameter("@PasswordRecoveryToken", token),
                new SqlParameter("@UserIP", HttpContext.Current.Request.UserHostAddress)
                        };
            if (DataAccess.ExecuteNonQuery(AppConfigurations.ConnectionString, "CA_Insert_PasswordRecovery", sqlParams))
            {
                return token;
            }
            return string.Empty;
        }

        public DataTable PasswordRecoveryCheck(string token, string email)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@Email", email),
                new SqlParameter("@PasswordRecoveryToken", token)
                        };

            return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "CA_Select_PasswordRecovery", sqlParams);
        }

        public bool PasswordReset(string email, string password)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@Email", email),
                new SqlParameter("@Password", password),
                new SqlParameter("@UserIP", HttpContext.Current.Request.UserHostAddress)
                        };

            return DataAccess.ExecuteNonQuery(AppConfigurations.ConnectionString, "CA_Update_Password", sqlParams);
        }

        public DataTable ChangePassword(int customerId, string oldPassword, string newPassword)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@clientId", customerId),
                new SqlParameter("@NewPassword", newPassword),
                new SqlParameter("@OldPassword", oldPassword),
                new SqlParameter("@UserIP", HttpContext.Current.Request.UserHostAddress)
                        };

            return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "CA_Update_ChangePassword", sqlParams);
        }


        //public async Task<bool> AddVisitor(VisitorModel visitorModel)
        //{
        //    SqlParameter[] sqlParams = {
        //        new SqlParameter("@LandingUrl", visitorModel.LandingUrl),
        //        new SqlParameter("@ReferrerUrl", visitorModel.ReferrerUrl),
        //        new SqlParameter("@UserAgent", visitorModel.UserAgent),
        //        new SqlParameter("@Country", visitorModel.Country),
        //        new SqlParameter("@Region", visitorModel.Region),
        //        new SqlParameter("@City", visitorModel.City),
        //        new SqlParameter("@Hostname", visitorModel.Hostname),
        //        new SqlParameter("@IP", visitorModel.IP),
        //        new SqlParameter("@Location", visitorModel.Location),
        //        new SqlParameter("@PostalCode", visitorModel.PostalCode),
        //        new SqlParameter("@Organization", visitorModel.Organization)
        //                };

        //    return await DataAccess.ExecuteNonQueryAsync(AppConfigurations.ConnectionString, "Insert_Visitor", sqlParams);
        //}



        //public DataTable GetAccountInfo(int customerId)
        //{
        //    SqlParameter[] sqlParams = { new SqlParameter("@customerId", customerId) };

        //    return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "CA_Select_AccountInfo", sqlParams);
        //}

        //public DataTable UpdateAccountInfo(int customerId, string name, string email, string cellFlag, string cellNo, string phoneFlag, string phoneNo)
        //{
        //    SqlParameter[] sqlParams = {
        //        new SqlParameter("@customerId", customerId),
        //        new SqlParameter("@Name", name),
        //        new SqlParameter("@Email", email),
        //        new SqlParameter("@CellFlag" , cellFlag),
        //        new SqlParameter("@CellNo" , cellNo),
        //        new SqlParameter("@PhoneFlag" , phoneFlag),
        //        new SqlParameter("@PhoneNo" , phoneNo),
        //        new SqlParameter("@UserIP", HttpContext.Current.Request.UserHostAddress)
        //                };

        //    return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "CA_Update_AccountInfo", sqlParams);
        //}

        //public DataSet GetOrderHistory(int customerId, DateTime? from, DateTime? to, int? pageSize, int? pageNumber)
        //{
        //    SqlParameter[] sqlParams = {
        //                           new SqlParameter("@customerId", customerId),
        //                           new SqlParameter("@PageNumber", pageNumber != 0 ? pageNumber : null ),
        //                           new SqlParameter("@PageSize", pageSize != 0 ? pageSize : null),
        //                           new SqlParameter("@From" , SqlDbType.DateTime) {Value = from.Equals(DateTime.MinValue) ? null : from } ,
        //                           new SqlParameter("@To" , SqlDbType.DateTime) {Value = to.Equals(DateTime.MinValue) ? null :  to}
        //                };

        //    return DataAccess.GetDataSet(AppConfigurations.ConnectionString, "CA_Select_OrderHistory", sqlParams);
        //}

        //public DataTable GetOrderDetailHistory(int orderId)
        //{
        //    SqlParameter[] sqlParams = {
        //        new SqlParameter("@OrderId", orderId)
        //                };

        //    return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "CA_Select_OrderDetailHistory", sqlParams);
        //}
        public string CompanyPasswordRecovery(string email)
        {
            string token = Guid.NewGuid().ToString();
            SqlParameter[] sqlParams = {
                new SqlParameter("@Email", email),
                new SqlParameter("@PasswordRecoveryToken",token),
                new SqlParameter("@UserIP", HttpContext.Current.Request.UserHostAddress)
                        };

            if (DataAccess.ExecuteNonQuery(AppConfigurations.ConnectionString, "Company_Insert_PasswordRecovery", sqlParams))
            {
                return token;
            }
            return string.Empty;
        }

        public DataTable CompanyPasswordRecoveryCheck(string token, string email)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@Email", email),
                new SqlParameter("@PasswordRecoveryToken", token)
                        };

            return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "Company_Select_PasswordRecovery", sqlParams);
        }

        public bool CompanyPasswordReset(string email, string password)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@Email", email),
                new SqlParameter("@Password", password),
                new SqlParameter("@UserIP", HttpContext.Current.Request.UserHostAddress)
                        };

            return DataAccess.ExecuteNonQuery(AppConfigurations.ConnectionString, "Company_Update_Password", sqlParams);
        }

        public DataTable CompanyChangePassword(int customerId, string oldPassword, string newPassword)
        {
            SqlParameter[] sqlParams = {
                new SqlParameter("@companyId", customerId),
                new SqlParameter("@NewPassword", newPassword),
                new SqlParameter("@OldPassword", oldPassword),
                new SqlParameter("@UserIP", HttpContext.Current.Request.UserHostAddress)
                        };

            return DataAccess.GetDataTable(AppConfigurations.ConnectionString, "Company_Update_ChangePassword", sqlParams);
        }


    }




}
