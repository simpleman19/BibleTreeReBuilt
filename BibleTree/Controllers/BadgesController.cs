using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BibleTree.Models;
using BibleTree.Services;


namespace BibleTree.Controllers
{
    public class BadgesController : Controller
    {
        public ActionResult BadgeTree()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("BadgeTree");
            }
            else
            {
                return View();
            }
        }
        // GET: Badges
        public ActionResult BadgeCreate()
        {
            BadgeType badge = new BadgeType(); 

            if (Request.IsAjaxRequest())
            {
                return PartialView("BadgeCreate", badge);
            }
            else
            {
                return View(badge);
            }
        }

        // POST: Badges
        [HttpPost]
        public void BadgeCreate(BadgeType badge)
        {
            SQLService database = new SQLService();
            database.AddBadgeWithoutId(badge);
        }

        public ActionResult BadgeEdit(int Id)
        {
            // Database call to get one with id
            BadgeType badge = new BadgeType();
            badge.badge_description = "Testing Description";
            badge.badge_name = "Badge Name";
            badge.badge_id = 1;
            badge.badge_activeDate = new DateTime(2016, 10, 4);
            badge.badge_expirationDate = new DateTime(2016, 10, 20);

            if (Request.IsAjaxRequest())
            {
                return PartialView("BadgeEdit", badge);
            }
            else
            {
                return View(badge);
            }
        }
        
        public ActionResult BadgeView(int id)
        {
            BadgeType badge = new BadgeType();
            SQLService db = new SQLService();
            if (id != 0)
            {
                db.GetBadgeById(id);
            } else
            {
                db.GetBadgeById(1);
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("BadgeView", badge);
            }
            else
            {
                return View(badge);
            }
        }

        public ActionResult SendBadge()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("BadgeSend");
            }
            else
            {
                return View();
            }
        }

        public ActionResult BadgeList()
        {
            SQLService database = new SQLService();
            var badgeList = database.GetBadges();

            if (Request.IsAjaxRequest())
            {
                return PartialView("BadgeList", badgeList);
            }
            else
            {
                return View(badgeList);
            }
        }
    }
}