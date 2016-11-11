using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace BibleTree.Models
{
	[Serializable, DisplayName("Faculty Member")]
    public class Faculty : User
    {
		[DisplayName("Position")] public string faculty_position {get; set;}
		[DisplayName("Department")] public string faculty_department {get; set;}
    }
}