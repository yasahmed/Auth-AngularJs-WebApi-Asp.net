using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace AuthWebApiKios.Helpers
{
    public class SendMail
    {
         
        public static bool Send(string toAddress, string subject, string body)
        {
            try
            {
                string SmtpServerUrl = ConfigurationManager.AppSettings["conf_smtp_server"].ToString();
                int SmtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["conf_smtp_port"].ToString());
                string FromAddress = ConfigurationManager.AppSettings["conf_smtp_user"].ToString();
                string Password = ConfigurationManager.AppSettings["conf_smtp_password"].ToString();
 
                SmtpClient SmtpServer = new SmtpClient(SmtpServerUrl);
                var mail = new MailMessage();
                mail.From = new MailAddress(FromAddress);
                mail.To.Add(toAddress);
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                string htmlBody;
                htmlBody = body;
                mail.Body = htmlBody;
                SmtpServer.Port = SmtpPort;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(FromAddress, Password);
                SmtpServer.EnableSsl = true;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }
    }
}