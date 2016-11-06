using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using BibleTree.Models;
using Dapper.Contrib.Extensions;

namespace BibleTree.Services {
	public class SQLService {

		private readonly string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=User;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		private  IDbConnection connect() => new SqlConnection(_connectionString);

		public SQLService(string connectionString) {
			_connectionString = connectionString;
		}

		/*
		 * =======================================
		 *     User Operations
		 */
		public User GetUserById(int user_id) {
			using (var db = connect()) {
				return db.Get<User>(user_id);
			}
		}
		public List<User> GetUsers() {
			using (var db = connect()) {
				return db.GetAll<User>().AsList();
			}
		}
		public void AddUser(User user) {
			using (var db = connect()) {
				throw new NotImplementedException();
			}
		}
		public void UpdateUser(User user) {
			using (var db = connect()) {
				throw new NotImplementedException();
			}
		}

		/*
		 * =======================================
		 *     Student Operations
		 */
		public Student GetStudentById(int user_id) {
			//throw new NotImplementedException();
			using (var db = connect()) {
				const string sql = @"SELECT Student.*, User.* 
										FROM Student, User 
										WHERE Student.user_id = User.user_id 
										AND User.user_id = @User_id";
				return db.Query<Student, User, Student>(sql,
					(s, u) => {
						s.user = u;
						return s;
					},
					new { User_id = user_id },
					splitOn: "User_id"
				).FirstOrDefault();
			}
		}
		public List<Student> GetStudents() {
			using (var db = connect()) {
				const string sql = @"SELECT Student.*, User.* 
										FROM Student, User 
										WHERE Student.user_id = User.user_id";
				return db.Query<Student, User, Student>(sql,
					(s, u) => {
						s.user = u;
						return s;
					},
					splitOn: "User_id"
				).AsList();
			}
		}
		public void AddStudent(Student student) {
			using (var db = connect()) {
				throw new NotImplementedException();
			}
		}
		public void UpdateStudent(Student student) {
			using (var db = connect()) {
				throw new NotImplementedException();
			}
		}

		/*
		 * =======================================
		 *     Administrator Operations
		 */
		public Administrator GetAdministratorById(int user_id) {
			using (var db = connect()) {
				const string sql = @"SELECT Administrator.*, User.* 
										FROM Administrator, User 
										WHERE Administrator.user_id = User.user_id 
										AND User.user_id = @User_id";
				return db.Query<Administrator, User, Administrator>(sql,
					(a, u) => {
						a.user = u;
						return a;
					},
					new { User_id = user_id },
					splitOn: "User_id"
				).FirstOrDefault();
			}
		}
		public List<Administrator> GetAdministrators() {
			using (var db = connect()) {
				const string sql = @"SELECT Administrator.*, User.* 
										FROM Administrator, User 
										WHERE Administrator.user_id = User.user_id";
				return db.Query<Administrator, User, Administrator>(sql,
					(a, u) => {
						a.user = u;
						return a;
					},
					splitOn: "User_id"
				).AsList();
			}
		}
		public void AddAdministrator(Administrator administrator) {
			using (var db = connect()) {
				throw new NotImplementedException();
			}
		}
		public void UpdateAdministrator(Administrator administrator) {
			using (var db = connect()) {
				throw new NotImplementedException();
			}
		}

		/*
		 * =======================================
		 *     Faculty Operations
		 */
		public Faculty GetFacultyById(int user_id) {
			using (var db = connect()) {
				const string sql = @"SELECT Faculty.*, User.* 
										FROM Faculty, User 
										WHERE Faculty.user_id = User.user_id 
										AND User.user_id = @User_id";
				return db.Query<Faculty, User, Faculty>(sql,
					(f, u) => {
						f.user = u;
						return f;
					},
					new { User_id = user_id },
					splitOn: "User_id"
				).FirstOrDefault();
			}
		}
		public List<Faculty> GetFaculty() {
			using (var db = connect()) {
				const string sql = @"SELECT Faculty.*, User.* 
										FROM Faculty, User 
										WHERE Faculty.user_id = User.user_id";
				return db.Query<Faculty, User, Faculty>(sql,
					(f, u) => {
						f.user = u;
						return f;
					},
					splitOn: "User_id"
				).AsList();
			}
		}
		public void AddFaculty(Faculty faculty) {
			using (var db = connect()) {
				throw new NotImplementedException();
			}
		}
		public void UpdateFaculty(Faculty faculty) {
			using (var db = connect()) {
				throw new NotImplementedException();
			}
		}

		/*
		 * =======================================
		 *     Badge Operations
		 */
		public void AddBadge(Badge badge) {
			using (var db = connect()) {
				const string sql = @"INSERT INTO Badge
                                         VALUES badge_id = @id
											,badge_name = @name
											,badge_description = @description
                                            ,badge_level = @level
                                            ,badge_activeDate = @activeDate
											,badge_expirationDate = @expirationDate
											,badge_gifURL = @gifURL
											,badge_pngURL = @pngURL";
				db.Execute(sql, badge);
			}
		}
		public void UpdateBadge(Badge badge) {
			using (var db = connect()) {
				const string sql = @"UPDATE Badge
										SET badge_id = @id
                                            ,badge_name = @name
                                            ,badge_description = @description
                                            ,badge_level = @level
                                            ,badge_activeDate = @activeDate
											,badge_expirationDate = @expirationDate
											,badge_gifURL = @gifURL
											,badge_pngURL = @pngURL
                                        WHERE badge_id = @id";
				db.Execute(sql, badge);
			}
		}
		public List<Badge> GetBadges() {
			using (var db = connect()) {
				return db.GetAll<Badge>().AsList();
			}
		}
		public Badge GetBadgeById(int user_id) {
			using (var db = connect()) {
				return db.Get<Badge>(user_id);
			}
		}

		/*
		 * =======================================
		 *     AwardedBadge Operations
		 */
		public List<AwardedBadge> GetUserAwards(int user_id) {
			using (var db = connect()) {
				const string sql = @"SELECT AwardedBadge.*, Badge.* 
										FROM AwardedBadge, Badge 
										WHERE AwardedBadge.user_id = @user_id";
				return db.Query<AwardedBadge, Badge, AwardedBadge>(sql,
					(a, b) => {
						a.badge = b;
						return a;
					},
					splitOn: "badge_id"
				).AsList();
			}
		}
		public void AssignAward(AwardedBadge awardedbadge) {
			using (var db = connect()) {
				const string sql = @"INSERT INTO AwardedBadge
										(User_id, Badge_id, Award_sentId, Award_date, Award_comment)
									VALUES @user_id,
										@badge_id,
										@award_sentid,
										@award_date,
										@award_comment";
				db.Execute(sql, awardedbadge);
			}
		}
		public void RevokeAward(AwardedBadge awardedbadge) {
			using (var db = connect()) {
				const string sql = @"DELETE FROM AwardedBadge
									WHERE AwardedBadge.user_id = @user_id
									AND AwardedBadge.badge_id = @badge_id";
				db.Execute(sql, awardedbadge);
			}
		}

	}
}