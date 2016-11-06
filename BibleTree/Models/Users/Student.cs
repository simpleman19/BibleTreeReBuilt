using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace BibleTree.Models
{
	[Serializable, DisplayName("Student")]
    public class Student : UserTemplate
    {
		[DisplayName("Student ID")] public long student_id {get; set;}
		[DisplayName("Enrollment Date")] public DateTime enrolment_date {get; set;}
		[DisplayName("Graduation Date")] public DateTime graduation_date {get; set;}
		[DisplayName("Student Badge List")] public List<BadgeInstance> badgeList { get; set; }
    }
}