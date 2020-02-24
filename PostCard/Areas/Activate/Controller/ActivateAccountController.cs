using PostCard.Controllers;
using PostCard.Database;
using PostCard.Helpers;
using PostCard.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostCard.Areas.Activate
{
    public class ActivateAccountController: HomeController
    {
        private Database.UserContext db = new Database.UserContext();
        public ActionResult AccountActivated()
        {
            NameValueCollection QueryString = new NameValueCollection();
            string hash = Request.QueryString["parameter"];
            TempData["parameter"] = hash;
            string nick = Request.QueryString["parameter2"];
            TempData["parameter2"] = nick;
            using (db)
            {
                var query = db.UserDb
                                   .Where(x => x.Nick == nick)
                                   .FirstOrDefault();
                string confirmHash = HashHelper.Hash(query.Email + "PCard");
                if (hash == confirmHash)
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
    }
}