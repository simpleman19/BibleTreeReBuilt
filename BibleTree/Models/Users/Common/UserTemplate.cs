using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace BibleTree.Models
{
	[Serializable]
    public class UserTemplate
    {
		[DisplayName("User Name")] public string name { get; set; };
		[DisplayName("Email")] public string email { get; set; };
		[NonSerialized] public string token { get; set; };
		public long unique_id { get; set; };
		
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