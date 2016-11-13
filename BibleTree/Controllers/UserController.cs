using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BibleTree.Models;

namespace BibleTree.Controllers
{
    public class UserController : Controller
    {
        public ActionResult UserHome()
        {
            BadgeType badge = new BadgeType();
            badge.badge_description = "Testing Description";
            badge.badge_name = "Badge Name";
            badge.badge_id = 1;

            return View(badge);
        }
    }
}