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
    public class UserController : Controller
    {
        public ActionResult UserHome()
        {
            //if (User.Identity.IsAuthenticated == false)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            BadgeType badge = new BadgeType();
            badge.badge_description = "Testing Description";
            badge.badge_name = "Badge Name";
            badge.badge_id = 1;

            return View(badge);
        }

        public ActionResult StudentList()
        {
            //if (User.Identity.IsAuthenticated == false)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            SQLService database = new SQLService();
            var userList = database.GetStudents();

            return View("StudentList", userList);
        }
        public ActionResult UserSearch()
        {
            //if (User.Identity.IsAuthenticated == false)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            //SQLService db = new SQLService();
            //var students = db.GetStudents();

            //return PartialView(students);
            SQLService database = new SQLService();
            var userList = database.GetStudents();
            return View("StudentSearchModal", userList);
        }

    }
}