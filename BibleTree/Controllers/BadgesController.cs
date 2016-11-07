﻿using System;
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
            badge.description = "Testing Description";
            badge.name = "Badge Name";
            badge.unique_id= 1;
            badge.availability = new BadgeAvailability();
            badge.availability.start_availability_date = new DateTime(2016, 10, 4);
            badge.availability.end_availability_date = new DateTime(2016, 10, 20);

            return View(badge);
        }
        
        public ActionResult BadgeView()
        {
            // Database call to get one with id
            BadgeType badge = new BadgeType();
            badge.description = "Testing Description";
            badge.name = "Badge Name";
            badge.unique_id = 1;
            badge.availability = new BadgeAvailability();
            badge.availability.start_availability_date = new DateTime(2016,10,4);
            badge.availability.end_availability_date = new DateTime(2016, 10, 20);
            return View(badge);
        }
    }
}