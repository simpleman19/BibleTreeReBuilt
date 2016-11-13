using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace BibleTree.Models
{
	[Serializable, DisplayName("Student")]
    public class Student : User
    {
		[DisplayName("Student ID")] public string student_id {get; set;}
		[DisplayName("Enrollment Date")] public DateTime student_dateEnrolled {get; set;}
		[DisplayName("Graduation Date")] public DateTime student_dateGraduated {get; set;}
		[DisplayName("Student Badge List")] public List<BadgeInstance> badgeList { get; set; }
    }
}