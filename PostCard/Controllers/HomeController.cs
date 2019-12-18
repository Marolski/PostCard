using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using PostCard.Database;
using PostCard.Models;

namespace PostCard.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db = new UserContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.Verified = false;
                db.User.Add(user);
                db.SaveChanges();
                string body = "kliknij w <a href=\"https://localhost:44385/Home/Login\">klik</a> aby potwierdzic konto";
                MailMessage mail = new MailMessage("mbrzoska303@gmail.com", user.Email,"potwierdzenie",body);
                mail.IsBodyHtml = true;
                Server().Send(mail);
                return View("Succesful", user);
            }
            else
            {
                string error = "Dane nie zostały poprawnie zwalidowane";
                return View("ErrorPage", error);
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        public SmtpClient Server()
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