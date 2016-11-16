using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BibleTree.Services;
using BibleTree.Models;

namespace BibleTree.Controllers
{
    public class ModalController : Controller
    {
        // GET: Modal
        public ActionResult Index()
        {
            return Content("Index");
        }

        public ActionResult StudentSearch()
        {
            SQLService db = new SQLService();
            var students = db.GetStudents();

            return PartialView(students);
        }
    }
}