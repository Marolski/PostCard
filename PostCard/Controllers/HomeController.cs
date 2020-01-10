using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using PostCard.Database;
using PostCard.Models;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Specialized;
using System.Data.SqlClient;

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
            user.Date = DateTime.Now;
            string hashName = Hash(user.Password);
            user.Hash = hashName;
            if (user.Password != user.ConfirmPassword)
            {
                throw new Exception("Hasła są nieprawidłowe");
            }
            else if (ModelState.IsValid)
            {
                user.Verified = false;
                db.User.Add(user);
                db.SaveChanges();
                Uri url = new Uri("https://localhost:44385/Home/Login?parameter=" + hashName+"&parameter2="+user.Nick);
                string body = "kliknij w <a href="+url+">klik</a> aby potwierdzic konto";
                MailMessage mail = new MailMessage("mbrzoska303@gmail.com", user.Email,"potwierdzenie",body);
                mail.IsBodyHtml = true;
                Server().Send(mail);
            }
            else
            {
                string error = "Dane nie zostały poprawnie zwalidowane";
                return View("ErrorPage", error);
            }
            return View("Succesful", user);
        }
        public ActionResult Login()
        {
            NameValueCollection QueryString = new NameValueCollection();
            string hash = Request.QueryString["parameter"];
            Console.WriteLine(hash);
            TempData["parameter"] = hash;
            string nick = Request.QueryString["parameter2"];
            Console.WriteLine(nick);
            TempData["parameter2"] = nick;
            using (db)
            {
                var query = db.User
                               .Where(x => x.Nick == nick)
                               .FirstOrDefault<User>();
                Console.WriteLine(query);
                if (hash==query.Hash)
                {
                    query.Verified = true;
                    try
                    { 
                        db.SaveChanges();
                        TempData["confirm"] = "Konto zostało aktywowane!";
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
                else
                {
                    TempData["confirm"] = "Konto nie zostało aktywowane, skontaktuj się z administratorem.";
                }
            }
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
        public string Hash(string source)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] bytes = crypt.ComputeHash(Encoding.UTF8.GetBytes(source));
            foreach (byte theByte in bytes)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();

        }
    }
}