using System;
using System.Web.Mvc;
using BibleTree.Services;
using BibleTree.Models;

namespace BibleTree.Controllers
{
    public class TestingController : Controller
    {
        // GET: Debug
        public ActionResult Index() {
	        return View();
        }

	    public string Reset() {
		    SQLService sql = new SQLService();
			string result = sql.Rebuild();
		    return result;
	    }

	    public string SqlScripts() {
			string debug = "";
			foreach (var key in ScriptService.Scripts.Keys) {
				debug += key + ": <br/>" + ScriptService.Scripts[key] + "<br/><br/>";
			}
			if (ScriptService.Scripts.Count == 0) {
				debug = "No Scripts Found!";
			}
			return debug;
		}

	    public string Users() {
			string debug = "";
		    SQLService sql = new SQLService();
			foreach (var user in sql.GetUsers()) {
				debug += user.user_id + ": " + user + "<br/>";
			}
			return debug;
		}

	    public string SelfTest() {
			string debug = "";
		    SQLService sql = new SQLService();
		    try {
			    debug += "Rebuilding: ";
			    debug += Reset() + "<br/>";

			    debug += "<br/><br/>Adding user: id='1' name='test user'<br/>result: ";
			    sql.AddUserWithId(new User() {user_id = 1, user_name = "test user", user_email = "testuser@gmail.com", user_token = "usertoken"});
				debug += sql.GetUserById(1);

				debug += "<br/><br/>Adding faculty: id='2', name='test faculty'<br/>result: ";
				sql.AddFaculty(new Faculty() { user_id = 2, user_name = "test faculty", user_email = "testfaculty@gmail.com", user_token = "facultytoken", user_type = 'f', faculty_department = "testing", faculty_position = "tester" });
			    debug += sql.GetFacultyById(2);

				debug += "<br/><br/>Adding administrator: id='3', name='test admin'<br/>result: ";
				sql.AddAdministrator(new Administrator() { user_id = 3, user_name = "test admin", user_email = "testadmin@gmail.com", user_token = "admintoken" , user_type = 'a', administrator_permLevel = 1});
			    debug += sql.GetAdministratorById(3);

			    debug += "<br/><br/>Making user id='1' a student<br/>result: ";
				sql.AddStudent(new Student() {user_id = 1, student_id = "1234567", student_dateEnrolled = DateTime.Now, student_dateGraduated = DateTime.MaxValue});
				debug += sql.GetStudentById(1);

				debug += "<br/><br/>Adding 2 new users without specifying ID:";
				sql.AddUserWithoutId(new User() {user_name = "test user4", user_email = "testuser4@gmail.com", user_token = "user4token" });
				debug += "<br/>result 1:" + sql.GetUserById(4);
				sql.AddUserWithoutId(new User() {user_name = "test user5", user_email = "testuser5@gmail.com", user_token = "user5token" });
				debug += "<br/>result 2:" + sql.GetUserById(5);

				debug += "<br/><br/>Renaming user 4 to \"changed user\"<br/>result: ";
				User u = sql.GetUserById(4);
				u.user_name = "changed user";
				u.user_email = "changed@gmail.com";
				u.user_token = "changedtoken";
				sql.UpdateUser(u);
				debug += sql.GetUserById(4);

				//debug += "<br/><br/>Adding a badge\"test badge\"<br/>result: ";
				//sql.AddBadge(new BadgeType() { badge_id = 1, badge_name = "test badge", badge_description  = "a test badge", badge_level =""});

				debug += "<br/><br/>List of all users:";
			    foreach (var user in sql.GetUsers()) {
				    debug += "<br/>" + user;
			    }
				debug += "<br/><br/>List of all faculty:";
				foreach (var faculty in sql.GetFaculty()) {
					debug += "<br/>" + faculty;
				}
				debug += "<br/><br/>List of all administrators:";
				foreach (var admin in sql.GetAdministrators()) {
					debug += "<br/>" + admin;
				}
				debug += "<br/><br/>List of all students:";
				foreach (var student in sql.GetStudents()) {
					debug += "<br/>" + student;
				}
				debug += "<br/><br/>List of all badges:";
				foreach (var badge in sql.GetBadges()) {
					debug += "<br/>" + badge;
				}
				debug += "<br/><br/>List of all awards:";
				foreach (var award in sql.GetAwards()) {
					debug += "<br/>" + award;
				}

			} catch (Exception e) {
			    debug += "<br/><p style=\"color:red\">EXCEPTION: " + e.Message + "</p>";
		    }
		    return debug;
		}
    }
}