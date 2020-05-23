using PostCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PostCard.Areas.Login.Model;
using PostCard.Controllers;
using PostCard.Repository;
using PostCard.Database;
using PostCard.Helpers;
using System.Net.Mail;

namespace PostCard.Areas.Login.Controller
{
    [RouteArea("Login")]
    public class LoginController : HomeController
    {
        private UserContext db = new UserContext();
        UserRepository userRepo = new UserRepository();
        [HttpPost]
        public ViewResult Login(LoginViewModel loginViewModel)
        {
            string loginState = CheckData(loginViewModel.Nick, HashHelper.Hash(loginViewModel.Password));
            if (loginState == "Nieprawidłowe hasło")
            {
                ModelState.AddModelError("", "Nieprawidłowe hasło.");
                return View("~/Views/Home/Login.cshtml");
            }
            else if (loginState == "Nazwa użytkownika nie istnieje")
            {
                ModelState.AddModelError("Nick", "Nazwa użytkownika nie istnieje.");
                return View("~/Views/Home/Login.cshtml", loginViewModel);
            }
            HttpCookie cookies = new HttpCookie("UserData");
            cookies["username"] = loginViewModel.Nick;
            cookies["guide"] = userRepo.GetGuidByUsername(loginViewModel.Nick);
            cookies.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(cookies);

            return View("~/Areas/Login/Views/HomePageUser.cshtml", loginViewModel);
        }
        public ViewResult Reset(string email)
        {
            ViewBag.ShowAlert = false;
            string newPassword = StringGenerator.RandomString(10);
            string hashedPassword = HashHelper.Hash(newPassword);
            using (var dbUser = new UserContext())
            {
                User user = userRepo.GetUserByEmail(email);
                if (user!=null)
                {
                    user.Password = hashedPassword;
                    db.SaveChanges();
                    string body = "nowe hasło do serwisu: "+newPassword;
                    MailMessage mail = new MailMessage("mbrzoska303@gmail.com", user.Email, "potwierdzenie", body);
                    mail.IsBodyHtml = true;
                    MailServerHelper.Server().Send(mail);
                    ViewBag.ShowAlert = true;
                }
            }
            return View("~/Views/Home/ResetPassword.cshtml");
        }
        public string CheckData(string nick, string password)
        {
            using (var dbUser = new Database.UserContext())
            {
                User user = userRepo.GetUserByUsername(nick);
                if (dbUser.UserDb.Any(o => o.Nick == nick))
                {
                    if (user.Password != password)
                    {
                        return "Nieprawidłowe hasło";
                    }
                    
                } else return "Nazwa użytkownika nie istnieje";


            }
            return "";
        }
        public void CheckGuide(HttpCookie cookie)
        {
            string userGuide = userRepo.GetGuidByUsername(cookie["username"]);
            if (userGuide != cookie["guide"])
            {
                throw new Exception("No authorization");

            }
        }
    }
}