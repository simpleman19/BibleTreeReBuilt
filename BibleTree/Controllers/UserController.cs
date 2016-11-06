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
            badge.description = "Testing Description";
            badge.name = "Badge Name";
            badge.unique_id = 1;

            return View(badge);
        }
    }
}