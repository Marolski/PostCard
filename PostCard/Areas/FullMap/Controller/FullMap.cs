using PostCard.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostCard.Areas.FullMap.Controller
{
    public class FullMap : HomeController
    {
        public ViewResult GetFullMap()
        {
            return View("FullMap");
        }
    }
}