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
            // Row 100 use 6 and 7
            // Row 200 use 4, 6, 7
            // Row 300 use 4, 5, 6, 7, 9
            // Row 400 dont use 1, 2, 8, 11, 12
            // Row 500 dont use 1, 3, 8, 12
            // Row 600 dont use 1, 3, 8, 12
            // Row 700 dont use 3, 10
            // Row 1000 dont use 12
            // Core 1205, 1105 905, 1006, 1007, 1008, 1208
            int[] core = new int[7] { 1205, 1105, 905, 1006, 1007, 1008, 1208 };
            List<int> spaces = new List<int>();
            for (int y=100; y < 1201; y+=100)
            {
                for(int x=1; x < 13; x++)
                {
                    spaces.Add(y + x);
                }
            }
            int[] badSpaces = new int[] { 101, 102, 103, 104, 105, 108, 109, 110, 111, 112,
                                            201, 202, 203, 205, 208, 209, 210, 211, 212,
                                            301, 302, 303, 308, 310, 311, 312,
                                            401, 402, 408, 411, 412,
                                            501, 503, 508, 512,
                                            601, 603, 608, 612,
                                            703, 710,
                                            1012 };
            foreach(int i in badSpaces)
            {
                spaces.Remove(i);
            }
            foreach (int i in core)
            {
                spaces.Remove(i);
            }
            SQLService db = new SQLService();
            List<BadgeInstance> badges = db.GetUserAwards(1010);
            Random rnd = new Random();
            foreach(BadgeInstance inst in badges)
            {
                if (inst.badge_type.badge_level == BadgeType.Badge_Level.CORE)
                {
                    if (inst.award_xcoord == 0)
                    {
                        int i = spaces.ToArray()[rnd.Next(0, spaces.Count)];
                        int x = i / 100;
                        x = x * 100;
                        int y = i - x;
                        inst.award_xcoord = x;
                        inst.award_ycoord = y;
                        db.UpdateAwardCoordinates(inst);
                    }
                }
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("BadgeTree", badges);
            }
            else
            {
                return View(badges);
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
        public ActionResult StudentBadges(int id)
        {
            return View();
        }
    }
}