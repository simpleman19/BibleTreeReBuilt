using System;
using System.ComponentModel;
using Dapper.Contrib.Extensions;
using Newtonsoft.Json;

namespace BibleTree.Models
{
	[Serializable]
    public class User
    {
		[DisplayName("User Name")] public string user_name { get; set; }

		[DisplayName("Email")] public string user_email { get; set; }

        public string user_token { get; set; }

		[Key] public long user_id { get; set; }

	    public char user_type { get; set; }

		public bool user_active { get; set; }

	    public void mapUser(User u) {
		    user_name = u.user_name;
		    user_email = u.user_email;
		    user_token = u.user_token;
		    user_id = u.user_id;
			user_type = u.user_type;
	    }

	    public override string ToString() {
		    return "{ user_id:'" + user_id + "' user_name:'" + user_name + "' user_email:'" + user_email + "' user_token:'" + user_token + "' user_type:'" + user_type.ToString() + "'}";
	    }

	    /*
		By design these should be here.
		Now that it's come to it it seems pretty obvious they shouldn't though.
		Only students have a badgelist.  I've moved that to the student class.
		User type is apparent as a part of the class inheriting this.
			(maybe these were here in case a student became a faculty member?)
		
		public List<BadgeInstance> badgeList { get; set; };
        public enum User_Type {STUDENT, FACULTY, ADMINISTRATION}
		public User_Type user_type { get; set; };
		*/
    }
}