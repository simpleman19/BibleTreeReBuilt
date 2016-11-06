using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibleTree.Controllers
{
    public class BadgesController : Controller
    {
        // GET: Badges
        public ActionResult BadgeCreate()
        {
            return View();
        }

        public ActionResult BadgeEdit()
        {
            return View();
        }
        
        public ActionResult BadgeView()
        {
            return View();
        }
    }
}