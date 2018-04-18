using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace RenocanWeb.Models
{
    public class EmailManager
    {
        public static void AppSettings(out string UserID, out string Password, out string SMTPPort, out string Host)
        {
            UserID = ConfigurationManager.AppSettings.Get("UserID");
            Password = ConfigurationManager.AppSettings.Get("Password");
            SMTPPort = ConfigurationManager.AppSettings.Get("SMTPPort");
            Host = ConfigurationManager.AppSettings.Get("Host");
        }
        public static void SendEmail(string From, string Subject, string Body, string To, string UserID, string Password, string SMTPPort, string Host)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(To);
            mail.From = new MailAddress(From);
            mail.Subject = Subject;
            mail.Body = Body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = Host;
            smtp.Port = Convert.ToInt16(SMTPPort);
            smtp.Credentials = new NetworkCredential(UserID, Password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        //private void SendEMail(string emailid, string subject, string body)
        //{
        //    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
        //    client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        //    client.EnableSsl = true;
        //    client.Host = "smtp.gmail.com";
        //    client.Port = 587;


        //    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("xxxxx@gmail.com", "password");
        //    client.UseDefaultCredentials = false;
        //    client.Credentials = credentials;

        //    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
        //    msg.From = new MailAddress("xxxxx@gmail.com");
        //    msg.To.Add(new MailAddress(emailid));

        //    msg.Subject = subject;
        //    msg.IsBodyHtml = true;
        //    msg.Body = body;

        //    client.Send(msg);
        //}
    }
}