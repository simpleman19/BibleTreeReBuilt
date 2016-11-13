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
            badge.badge_description = "Testing Description";
            badge.badge_name = "Badge Name";
            badge.badge_id = 1;

            return View(badge);
        }
        
        public ActionResult BadgeView()
        {
            // Database call to get one with id
            BadgeType badge = new BadgeType();
            badge.badge_description = "Testing Description";
            badge.badge_name = "Badge Name";
            badge.badge_id = 1;

            return View(badge);
        }
        public ActionResult SendBadge()
        {
            return View();
        }

        public ActionResult BadgeList()
        {
            var badgeList = new List<BadgeType>{
                            new BadgeType() { badge_name = "Test Badge 1", badge_description = "Just first test badge", badge_id = 1 } ,
                            new BadgeType() { badge_name = "Test Badge 2", badge_description = "Second test badge" ,  badge_id = 2 } ,
                            new BadgeType() { badge_name = "Test Badge 3", badge_description = "Third test badge", badge_id = 3} ,
                            new BadgeType() { badge_name = "Test Badge 4", badge_description = "Another stupid test badge", badge_id = 4} ,
                        };
            return View(badgeList);
        }
    }
}