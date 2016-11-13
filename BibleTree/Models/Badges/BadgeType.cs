using System;
using System.ComponentModel;
using Dapper.Contrib.Extensions;

namespace BibleTree.Models
{
	[Serializable, DisplayName("Badge Type")]
    public class BadgeType
    {
        public enum Badge_Level { CORE = 1, COMPETENCY = 2, COMMENDATION = 3 }

		[DisplayName("Name")] public string badge_name { get; set; }
		[DisplayName("PNG URL")] public string badge_pngURL { get; set; }
		[DisplayName("GIF URL")] public string badge_gifURL { get; set; }
		[DisplayName("Description")] public string badge_description { get; set; }



		[Key] public long badge_id { get; set; }
		[DisplayName("Availability")] public BadgeAvailability badge_availability { get; set; }
		[DisplayName("Badge Level")] public Badge_Level badge_level { get; set; }

    }
}