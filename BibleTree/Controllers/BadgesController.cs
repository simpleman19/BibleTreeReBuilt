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

            if (Request.IsAjaxRequest())
            {
                return PartialView("BadgeEdit", badge);
            }
            else
            {
                return View(badge);
            }
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
            var badgeList = new List<BadgeType>{
                            new BadgeType() { name = "Test Badge 1", description = "Just first test badge", unique_id = 1 } ,
                            new BadgeType() { name = "Test Badge 2", description = "Second test badge" ,  unique_id = 2 } ,
                            new BadgeType() { name = "Test Badge 3", description = "Third test badge", unique_id = 3} ,
                            new BadgeType() { name = "Test Badge 4", description = "Another stupid test badge", unique_id = 4} ,
                        };
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