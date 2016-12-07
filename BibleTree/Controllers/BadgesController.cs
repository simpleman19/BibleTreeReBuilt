using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BibleTree.Models;
using BibleTree.Services;


namespace BibleTree.Controllers
{
    [RequireHttps]
    public class BadgesController : Controller
    {
        public ActionResult BadgeTree()
        {
            //if (User.Identity.IsAuthenticated == false)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

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
            //if (User.Identity.IsAuthenticated == false)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

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
            //if (User.Identity.IsAuthenticated == false)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            SQLService database = new SQLService();
            database.AddBadgeWithoutId(badge);
        }

        public ActionResult BadgeEdit(int Id)
        {
            //if (User.Identity.IsAuthenticated == false)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

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
            //if (User.Identity.IsAuthenticated == false)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            SQLService database = new SQLService();
            database.UpdateBadge(badge);
        }

        public ActionResult BadgeView(int id)
        {
            //if (User.Identity.IsAuthenticated == false)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

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
            //if (User.Identity.IsAuthenticated == false)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

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
            //if (User.Identity.IsAuthenticated == false)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

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