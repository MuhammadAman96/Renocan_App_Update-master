using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Configuration;
namespace RenocanWeb.Models
{
    public class Email
    {
        public void CompanySendEmail(string token,string email)
        {
            string url = ConfigurationManager.AppSettings["RecoveryEmailLink"]+ "Business_Home/CompanyPasswordRecoveryConfirm?token="+ token +"&email=" +email;
            string msgBody = "<p>Dear user,</p><p>Please&nbsp; <a href='"+ url + "'>click here</a>&nbsp;to reset your password.</p><p> Regards,</p>  <p> Team Renocan </p> ";          
                MailMessage mm = new MailMessage("aman.ned96@gmail.com", email);
                mm.Subject = "Password Recovery";
                mm.Body = string.Format(msgBody);
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = "aman.ned96@gmail.com";
                NetworkCred.Password = "usamajan0336";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
               
            
        }


        public void ClientSendEmail(string token, string email)
        {
            string url = ConfigurationManager.AppSettings["RecoveryEmailLink"] + "ClientAccount/PasswordRecoveryConfirm?token=" + token + "&email=" + email;
            string msgBody = "<p>Dear user,</p><p>Please&nbsp; <a href='" + url + "'>click here</a>&nbsp;to reset your password.</p><p> Regards,</p>  <p> Team Renocan </p> ";
            MailMessage mm = new MailMessage("aman.ned96@gmail.com", email);
            mm.Subject = "Password Recovery";
            mm.Body = string.Format(msgBody);
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = "aman.ned96@gmail.com";
            NetworkCred.Password = "usamajan0336";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);


        }

    }
}