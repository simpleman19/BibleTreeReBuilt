using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace BibleTree.Models
{
	[Serializable, DisplayName("Faculty Member")]
    public class Faculty : UserTemplate
    {
		[DisplayName("Position")] public string position {get; set;}
		[DisplayName("Department")] public string department {get; set;}
    }
}