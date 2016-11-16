using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BibleTree.Models;
using BibleTree.Services;

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

        public ActionResult UserList()
        {
            SQLService database = new SQLService();
            var userList = database.GetStudents();

            return View("StudentList", userList);
        }
    }
}