using System;
using System.ComponentModel;
using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

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

        [DisplayName("Active Date")]
        [DataType(DataType.Date)]//changed line
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime badge_activeDate { get; set; }

        [DisplayName("Expire Date")]
        [DataType(DataType.Date)]//changed line
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime badge_expirationDate { get; set; }

		[Dapper.Contrib.Extensions.Key] public long badge_id { get; set; }
		[DisplayName("Badge Level")] public Badge_Level badge_level { get; set; }
		public bool badge_active { get; set; }

		public override string ToString() {
			return "{ badge_id:'" + badge_id + "' badge_name:'" + badge_name + "' badge_description:'" + badge_description + "' badge_activeDate:'" + badge_activeDate + "' badge_expirationDate:'" + badge_expirationDate + "' badge_level:'" + badge_level + "'}";
		}

    }
}