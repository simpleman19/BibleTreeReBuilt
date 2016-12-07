using BibleTree.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BibleTree.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                SQLService database = new SQLService();
                var users = database.GetUsers();

                foreach (var user in users)
                {
                    if (user.user_email == User.Identity.Name)
                    {
                        switch (user.user_type)
                        {
                            case 's':
                                return RedirectToAction("studenthome", "User");

                            case 'f':
                                return RedirectToAction("UserHome", "User");

                            case 'a':
                                return RedirectToAction("UserHome", "User");
                        }

                        break;
                    }
                }
            }

            return View();
        }

        public ActionResult BadgeCreate()
        {
            return View();
        }
    }
}