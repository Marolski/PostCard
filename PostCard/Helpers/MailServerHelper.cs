using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace PostCard.Helpers
{
    public class MailServerHelper
    {
        public static SmtpClient Server()
        {
            SmtpClient server = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("mbrzoska303@gmail.com", "marol123")
            };
            return server;
        }
    }
}