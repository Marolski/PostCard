using PostCard.Controllers;
using PostCard.Database;
using PostCard.Helpers;
using PostCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PostCard.Areas.Register.Controller
{
    public class RegisterController: HomeController
    {
        private Database.UserContext db = new Database.UserContext();
        private CreateGuideHelper guideHelper = new CreateGuideHelper();
        [HttpPost]
        public ViewResult Register(UserViewModel user)
        {
            if (user.TermsAndConditions == false)
            {
                return View("/Views/Home/Register");
            }

            User userDb = new User();
            userDb.Date = DateTime.Now;
            userDb.Verified = false;
            userDb.Guide = guideHelper.CreateGuide();
            string checkData = CheckData(user.Nick, user.Email);
            if (checkData == "Nazwa użytkownika jest zajęta")
            {
                ModelState.AddModelError("Nick", "Nazwa użytkownika jest zajęta");
                return View("~/Views/Home/Register.cshtml");
            }
            else if (checkData == "Email jest obecnie używany")
            {
                ModelState.AddModelError("Email", "Email jest obecnie używany");
                return View("~/Views/Home/Register.cshtml");
            }
            string toHash = user.Email + "PCard";
            string hashEmail = HashHelper.Hash(toHash);
            if (ModelState.IsValid)
            {
                userDb.Nick = user.Nick;
                userDb.Email = user.Email;
                userDb.Password = HashHelper.Hash(user.Password);
                db.UserDb.Add(userDb);
                db.SaveChanges();
                Uri url = new Uri("https://localhost:44385/ActivateAccount/Login?parameter=" + hashEmail + "&parameter2=" + userDb.Nick);
                string body = "kliknij w <a href=" + url + ">klik</a> aby potwierdzic konto";
                MailMessage mail = new MailMessage("mbrzoska303@gmail.com", userDb.Email, "potwierdzenie", body);
                mail.IsBodyHtml = true;
                MailServerHelper.Server().Send(mail);
            }
            else
            {
                string error = "Dane nie zostały poprawnie zwalidowane";
                return View("ErrorPage", error);
            }
            return View("Succesful", user);
        }

        public string CheckData(string nick, string email)
        {
            using (var dbUser = new Database.UserContext())
            {
                if (dbUser.UserDb.Any(o => o.Email == email))
                {
                    return "Email jest obecnie używany";
                }
                if (dbUser.UserDb.Any(o => o.Nick == nick))
                {
                    return "Nazwa użytkownika jest zajęta";
                }

            }
            return "";
        }
    }
}