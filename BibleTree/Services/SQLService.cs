using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using BibleTree.Models;

namespace BibleTree.Services {
	public class SQLService {

		/*
		 * =======================================
		 *     Primary Database Handling
		 */
		#region Connection
		private readonly string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=BibleTree;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		private readonly string _noDatabaseConnection = @"Data Source=.\SQLEXPRESS;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		private IDbConnection connect() => new SqlConnection(_connectionString);

		private IDbConnection noDatabaseConnect() => new SqlConnection(_noDatabaseConnection);


		public SQLService(string connectionString) {
			_connectionString = connectionString;
		}
		#endregion


		public SQLService() {}

		/*
		 * =======================================
		 *     Database Operations
		 */
		#region Database Operations
		public string Rebuild() {
			//Resets entire database with fresh empty model
			Drop();
			Create();
			return "success";
		}
		public void Drop() {
			using (var db = noDatabaseConnect()) {
				db.Execute(ScriptService.Scripts["database_drop"]);
			}
		}
		public void Create() {
			using (var db = noDatabaseConnect()) {
				ScriptService.Execute(db,"database_create");
			}
		}
		#endregion

		/*
		 * =======================================
		 *     User Operations
		 */
		#region User Operations
		public User GetUserById(int user_id) {
			//throw new NotImplementedException();
			using (var db = connect()) {
				return db.Query<User>(ScriptService.Scripts["user_getbyid"], new {user_id = user_id}).FirstOrDefault();
			}
		}
		public List<User> GetUsers() {
			using (var db = connect()) {
				//return db.GetAll<User>().AsList();
				return db.Query<User>(ScriptService.Scripts["user_getall"]).AsList();
			}
		}
		public void AddUserWithId(User user) {
			using (var db = connect()) {
				db.Execute(ScriptService.Scripts["user_insertwithid"], user);
			}
		}
		public void AddUserWithoutId(User user) {
			using (var db = connect()) {
				db.Execute(ScriptService.Scripts["user_insertwithoutid"], user);
			}
		}
		public void UpdateUser(User user) {
			using (var db = connect()) {
				db.Execute(ScriptService.Scripts["user_update"], user);
			}
		}
		#endregion

		/*
		 * =======================================
		 *     Student Operations
		 */
		#region Student Operations
		public Student GetStudentById(int user_id) {
			using (var db = connect()) {
				return db.Query<Student, User, Student>(ScriptService.Scripts["student_getbyid"],
					(s, u) => {
						s.mapUser(u);
						return s;
					},
					new { User_id = user_id },
					splitOn: "user_id"
				).FirstOrDefault();
			}
		}
		public List<Student> GetStudents() {
			using (var db = connect()) {
				return db.Query<Student, User, Student>(ScriptService.Scripts["student_getall"],
					(s, u) => {
						s.mapUser(u);
						return s;
					},
					splitOn: "user_id"
				).AsList();
			}
		}
		public void AddStudent(Student student) {
			using (var db = connect()) {
				ScriptService.Execute(db, "student_insert", student);
			}
		}
		public void UpdateStudent(Student student) {
			using (var db = connect()) {
				throw new NotImplementedException();
			}
		}
		#endregion

		/*
		 * =======================================
		 *     Administrator Operations
		 */
		#region Administrator Operations
		public Administrator GetAdministratorById(int user_id) {
			using (var db = connect()) {
				return db.Query<Administrator, User, Administrator>(ScriptService.Scripts["administrator_getbyid"],
					(a, u) => {
						a.mapUser(u);
						return a;
					},
					new { User_id = user_id },
					splitOn: "user_id"
				).FirstOrDefault();
			}
		}
		public List<Administrator> GetAdministrators() {
			using (var db = connect()) {
				return db.Query<Administrator, User, Administrator>(ScriptService.Scripts["administrator_getall"],
					(a, u) => {
						a.mapUser(u);
						return a;
					},
					splitOn: "user_id"
				).AsList();
			}
		}
		public void AddAdministrator(Administrator administrator) {
			using (var db = connect()) {
				ScriptService.Execute(db, "administrator_insert", administrator);
			}
		}
		public void UpdateAdministrator(Administrator administrator) {
			using (var db = connect()) {
				throw new NotImplementedException();
			}
		}
		#endregion

		/*
		 * =======================================
		 *     Faculty Operations
		 */
		#region Faculty Operations
		public Faculty GetFacultyById(int user_id) {
			using (var db = connect()) {
				return db.Query<Faculty, User, Faculty>(ScriptService.Scripts["faculty_getbyid"],
					(f, u) => {
						f.mapUser(u);
						return f;
					},
					new { User_id = user_id },
					splitOn: "user_id"
				).FirstOrDefault();
			}
		}
		public List<Faculty> GetFaculty() {
			using (var db = connect()) {
				return db.Query<Faculty, User, Faculty>(ScriptService.Scripts["faculty_getall"],
					(f, u) => {
						f.mapUser(u);
						return f;
					},
					splitOn: "user_id"
				).AsList();
			}
		}
		public void AddFaculty(Faculty faculty) {
			using (var db = connect()) {
				ScriptService.Execute(db, "faculty_insert", faculty);
			}
		}
		public void UpdateFaculty(Faculty faculty) {
			using (var db = connect()) {
				throw new NotImplementedException();
			}
		}
		#endregion

		/*
		 * =======================================
		 *     Badge Operations
		 */
		#region Badge Operations

		public void AddBadge(BadgeType badge) {
			using (var db = connect()) {
				db.Execute(ScriptService.Scripts["badge_insert"], badge);
			}
		}
		public void UpdateBadge(BadgeType badge) {
			using (var db = connect()) {
				db.Execute(ScriptService.Scripts["badge_update"], badge);
			}
		}
		public List<BadgeType> GetBadges() {
			using (var db = connect()) {
				return db.GetAll<BadgeType>().AsList();
			}
		}
		public BadgeType GetBadgeById(int badge_id) {
			using (var db = connect()) {
				return db.Get<BadgeType>(badge_id);
			}
		}
		#endregion

		/*
		 * =======================================
		 *     AwardedBadge Operations
		 */
		#region AwardedBadge Operations

		public List<BadgeInstance> GetUserAwards(int user_id) {
			using (var db = connect()) {
				return db.Query<BadgeInstance, BadgeType, BadgeInstance>(ScriptService.Scripts["awardedbadge_getbyuserid"],
					(a, b) => {
						a.badge_type = b;
						return a;
					}, user_id,
					splitOn: "badge_id"
				).AsList();
			}
		}
		public List<BadgeInstance> GetAwards() {
			using (var db = connect()) {
				return db.Query<BadgeInstance, BadgeType, BadgeInstance>(ScriptService.Scripts["awardedbadge_getall"],
					(a, b) => {
						a.badge_type = b;
						return a;
					},
					splitOn: "badge_id"
				).AsList();
			}
		}
		public void AssignAward(BadgeInstance awardedbadge) {
			using (var db = connect()) {
				db.Execute(ScriptService.Scripts["awardedbadge_insert"], awardedbadge);
			}
		}
		public void RevokeAward(BadgeInstance awardedbadge) {
			using (var db = connect()) {
				db.Execute(ScriptService.Scripts["awardedbadge_delete"], awardedbadge);
			}
		}
		#endregion

	}
}