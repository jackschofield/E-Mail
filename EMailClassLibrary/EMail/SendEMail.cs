using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace EMail
{
    public class SendEMail
    {
        public bool Send(string strSendFrom, string strSendTo, string strUserName, string strPassword, string strSubject, string strBody)
        {
            try
            {
                MailMessage mm = new MailMessage(strSendFrom, strSendTo);
                mm.IsBodyHtml = true;
                mm.Subject = strSubject;
                mm.Body = strBody;
                SmtpClient client = new SmtpClient("Auth.smtp.1and1.co.uk");
                client.Credentials = new NetworkCredential(strUserName, strPassword);
                client.Send(mm);
            }
            catch { return false; }
            return true;
        }
        public bool SendTest(string strSendTo, string strUserName, string strPassword)
        {
            try
            {
                MailMessage mm = new MailMessage("TestE-Mail", strSendTo);
                mm.Subject = "Test";
                mm.Body = "Do not reply. This is a test.";
                SmtpClient client = new SmtpClient("Auth.smtp.1and1.co.uk");
                client.Credentials = new NetworkCredential(strUserName, strPassword);
                client.Send(mm);
            }
            catch { return false; }
            return true;
        }
    }
}
