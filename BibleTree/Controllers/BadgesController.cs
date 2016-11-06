using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BibleTree.Models;


namespace BibleTree.Controllers
{
    public class BadgesController : Controller
    {
        // GET: Badges
        public ActionResult BadgeCreate()
        {
            BadgeType badge = new BadgeType();

            return View(badge);
        }

        public ActionResult BadgeEdit(int Id)
        {
            // Database call to get one with id
            BadgeType badge = new BadgeType();
            badge.Description = "Testing Description";
            badge.Name = "Badge Name";
            badge.Id_Num= 1;

            return View(badge);
        }
        
        public ActionResult BadgeView()
        {
            // Database call to get one with id
            BadgeType badge = new BadgeType();
            badge.Description = "Testing Description";
            badge.Name = "Badge Name";
            badge.Id_Num = 1;

            return View(badge);
        }
    }
}