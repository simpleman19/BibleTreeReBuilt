using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace BibleTree.Models
{
	[Serializable, DisplayName("Badge Type")]
    public class BadgeType
    {
        public enum Badge_Level { CORE, COMPETENCY, COMMENDATION }

		[DisplayName("Name")] public string name { get; set; }
		[DisplayName("PNG URL")] public string png_url { get; set; }
		[DisplayName("GIF URL")] public string gif_url { get; set; }
		[DisplayName("Description")] public string description { get; set; }
        [DisplayName("ID Number")] public long unique_id { get; set; }
		[DisplayName("Availability")] public BadgeAvailability availability { get; set; }
		[DisplayName("Badge Level")] public Badge_Level badge_level { get; set; }

    }
}