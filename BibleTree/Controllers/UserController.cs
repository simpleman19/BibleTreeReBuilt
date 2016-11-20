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

        public ActionResult StudentList()
        {
            SQLService database = new SQLService();
            var userList = database.GetStudents();
            
            if (Request.IsAjaxRequest())
            {
                return PartialView("StudentList", userList);
            }
            else
            {
                return View("StudentList", userList);
            }
        }
        public ActionResult StudentSearch()
        {
            //SQLService db = new SQLService();
            //var students = db.GetStudents();

            //return PartialView(students);
            SQLService database = new SQLService();
            var userList = database.GetStudents();
            return View("StudentSearchModal", userList);
        }

        public void DeleteStudent(int id)
        {
            // TODO add this action!
            SQLService db = new SQLService();
            if (id != 0)
            {
                // TODO delete the student
            }
            else
            {
                // TODO delete the student
            }
        }
        public ActionResult StudentDetails(int id)
        {
            // TODO
            // add view
            // Will show all of students data and badges
            // will also link to edit student's badges

            Student student = new Student();
            SQLService db = new SQLService();
            if (id != 0)
            {
                student = db.GetStudentById(id);
            }
            else
            {
                student = db.GetStudentById(1);
            }

            return View(student);
        }
        public ActionResult EditStudent(int id)
        {
            // TODO add this view !
            Student student = new Student();
            SQLService db = new SQLService();
            if (id != 0)
            {
                student = db.GetStudentById(id);
            }
            else
            {
                student = db.GetStudentById(1);
            }
            
            return View(student);
        }
        public ActionResult AddStudent()
        {
            // TODO add this view !
            Student student = new Student();

            return View(student);
        }
        
		
		
        public ActionResult FacultyList()
        {
            SQLService database = new SQLService();
            var userList = database.GetFaculty();
            
            if (Request.IsAjaxRequest())
            {
                return PartialView("FacultyList", userList);
            }
            else
            {
                return View("FacultyList", userList);
            }
        }
        public void DeleteFaculty(int id)
        {
            // TODO add this action!
            SQLService db = new SQLService();
            if (id != 0)
            {
                // TODO delete the faculty
            }
            else
            {
                // TODO delete the faculty
            }
        }
        public ActionResult FacultyDetails(int id)
        {
            // TODO add view
            // Will show all of faculty's data

            Faculty faculty = new Faculty();
            SQLService db = new SQLService();
            if (id != 0)
            {
                faculty = db.GetFacultyById(id);
            }
            else
            {
                faculty = db.GetFacultyById(1);
            }

            return View(faculty);
        }
        public ActionResult EditFaculty(int id)
        {
            // TODO add this view !
            Faculty faculty = new Faculty();
            SQLService db = new SQLService();
            if (id != 0)
            {
                faculty = db.GetFacultyById(id);
            }
            else
            {
                faculty = db.GetFacultyById(1);
            }

            return View(faculty);
        }
        public ActionResult AddFaculty()
        {
            // TODO add this view !
            Faculty faculty = new Faculty();

            return View(faculty);
        }
    }
}