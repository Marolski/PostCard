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
using PostCard.Helpers;

namespace PostCard.Controllers
{
    public class HomeController : Controller
    {
        private Database.UserContext db = new Database.UserContext();
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
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult GetFullMap()
        {
            return View("~/Areas/FullMap/Views/FullMap.cshtml");
        }
        public ActionResult ResetPassword()
        {
            ViewBag.ShowAlert = false;
            return View();
        }

    }
}