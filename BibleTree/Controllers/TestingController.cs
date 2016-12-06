using System;
using System.Web.Mvc;
using BibleTree.Services;
using BibleTree.Models;
using System.Data.SqlClient;

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
			SQLService sql = new SQLService();

			string debug = "<h3>User report</h3><br/>active:<br/>";
			foreach (var user in sql.GetActiveUsers()) {
				debug += user.user_id + ": " + user + "<br/>";
			}
			debug += "<br/><br/>deleted:<br/>";
			foreach (var user in sql.GetDeletedUsers()) {
				debug += user.user_id + ": " + user + "<br/>";
			}
			debug += "<br/><br/>all:<br/>";
			foreach (var user in sql.GetUsers()) {
				debug += user.user_id + ": " + user + "<br/>";
			}
			return debug;
		}

		public string Faculty() {
			SQLService sql = new SQLService();

			string debug = "<h3>Faculty report</h3><br/>active:<br/>";
			foreach (var user in sql.GetActiveFaculty()) {
				debug += user.user_id + ": " + user + "<br/>";
			}
			debug += "<br/><br/>deleted:<br/>";
			foreach (var user in sql.GetDeletedFaculty()) {
				debug += user.user_id + ": " + user + "<br/>";
			}
			debug += "<br/><br/>all:<br/>";
			foreach (var user in sql.GetFaculty()) {
				debug += user.user_id + ": " + user + "<br/>";
			}
			return debug;
		}
		public string Administrators() {
			SQLService sql = new SQLService();

			string debug = "<h3>Administrator report</h3><br/>active:<br/>";
			foreach (var user in sql.GetActiveAdministrators()) {
				debug += user.user_id + ": " + user + "<br/>";
			}
			debug += "<br/><br/>deleted:<br/>";
			foreach (var user in sql.GetDeletedAdministrators()) {
				debug += user.user_id + ": " + user + "<br/>";
			}
			debug += "<br/><br/>all:<br/>";
			foreach (var user in sql.GetAdministrators()) {
				debug += user.user_id + ": " + user + "<br/>";
			}
			return debug;
		}
		public string Students() {
			SQLService sql = new SQLService();

			string debug = "<h3>Student report</h3><br/>active:<br/>";
			foreach (var user in sql.GetActiveStudents()) {
				debug += user.user_id + ": " + user + "<br/>";
			}
			debug += "<br/><br/>deleted:<br/>";
			foreach (var user in sql.GetDeletedStudents()) {
				debug += user.user_id + ": " + user + "<br/>";
			}
			debug += "<br/><br/>all:<br/>";
			foreach (var user in sql.GetStudents()) {
				debug += user.user_id + ": " + user + "<br/>";
			}
			return debug;
		}
		public string Badges() {
			SQLService sql = new SQLService();

			string debug = "<h3>Badge report</h3><br/>all:<br/>";
			foreach (var badge in sql.GetBadges()) {
				debug += badge.badge_id + ": " + badge + "<br/>";
			}
			return debug;
		}
		public string AwardedBadges() {
			SQLService sql = new SQLService();
			string debug = "<h3>Award report</h3><br/>active:<br/>";
			foreach (var badge in sql.GetActiveAwards()) {
				debug += badge.badge_id + ": " + badge + "<br/>";
			}
			debug += "<br/><br/>deactivated:<br/>";
			foreach (var badge in sql.GetDeactivatedAwards()) {
				debug += badge.badge_id + ": " + badge + "<br/>";
			}
			debug += "<br/><br/>all:<br/>";
			foreach (var award in sql.GetAwards()) {
				debug += award.award_id + ": " + award + "<br/>";
			}
			return debug;
		}

		public void sendemail () {
			EmailService service = new EmailService();
			service.Contact(new BadgeInstance() {
				user_id = 1,
				badge_id = 1,
				award_sentid = 2,
				award_timestamp = DateTime.Now,
				award_comment = "This is a test award"
			});	
		}

	    public string SelfTest() {
			string debug = "";
		    SQLService sql = new SQLService();
			EmailService em = new EmailService();
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

				debug += "<br/><br/>Renaming user 1 to \"Test Student\"<br/>result: ";
				User u = sql.GetUserById(1);
				u.user_name = "Test Student";
				u.user_email = "bibletreeproject@gmail.com";
				u.user_token = "changedtoken";
				sql.UpdateUser(u);
				debug += sql.GetUserById(1);

				debug += "<br/><br/>Adding a badge\"test badge\" with id 1<br/>result: ";
				sql.AddBadgeWithId(new BadgeType() { badge_id = 1, badge_name = "test badge", badge_description  = "a test badge", badge_level = BadgeType.Badge_Level.CORE, badge_activeDate = DateTime.Now, badge_expirationDate = DateTime.MaxValue, badge_gifURL= "http://www.oc.edu/academics/graduate/theology/images/digital-badge-images/faculty-student-badges/animated-gif-images/304%20Quality%20Commenter.gif" });
				debug += sql.GetBadgeById(1);

				debug += "<br/><br/>Adding another  badge\"test badge2\" without specific id<br/>result: ";
				sql.AddBadgeWithoutId(new BadgeType() { badge_name = "test badge 2", badge_description = "a second test badge", badge_level = BadgeType.Badge_Level.CORE, badge_activeDate = DateTime.Now, badge_expirationDate = DateTime.MaxValue });
				debug += sql.GetBadgeById(2);

				debug += "<br/><br/>Awarding badge_id = 1 to user_id = 1<br/>result: ";
				BadgeInstance awardedBadge = new BadgeInstance() { badge_id = 1, award_sentid = 2, award_comment = "this is a test award", award_timestamp = DateTime.Now, user_id = 1 };
				sql.AssignAward(awardedBadge);

				debug += "<br/><br/>Sending user_id = 1 an award email<br/>";
				em.Contact(awardedBadge);

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

			} catch (SqlException e) {
				debug += "<br/><p style=\"color:orange\">SQL EXCEPTION: " + e.Message + "</p>";
			} catch (Exception e) {
				debug += "<br/><p style=\"color:red\">SERVER EXCEPTION: " + e.Message + "</p>";  
		    }
		    return debug;
		}
    }
}