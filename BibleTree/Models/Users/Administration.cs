using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace BibleTree.Models
{
	[Serializable, DisplayName("Administrator")]
    public class Administration : UserTemplate
    {
		[DisplayName("Administrative Permissions Level")] public string permissions_level { get; set; }
    }
}