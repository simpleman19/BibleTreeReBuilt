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
            SQLService db = new SQLService();
            BadgeType badge = db.GetBadgeById(Id);

            if (Request.IsAjaxRequest())
            {
                return PartialView("BadgeEdit", badge);
            }
            else
            {
                return View(badge);
            }
        }

        [HttpPost]
        public void BadgeEdit(BadgeType badge)
        {
            SQLService database = new SQLService();
            database.UpdateBadge(badge);
        }

        public ActionResult BadgeView(int id)
        {
            BadgeType badge = new BadgeType();
            SQLService db = new SQLService();
            if (id != 0)
            {
                badge = db.GetBadgeById(id);
            } else
            {
                badge = db.GetBadgeById(1);
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
                return PartialView("SendBadge");
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