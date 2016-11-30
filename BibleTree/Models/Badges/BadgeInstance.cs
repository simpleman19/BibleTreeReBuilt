using System;
using System.ComponentModel;
using Dapper.Contrib.Extensions;

namespace BibleTree.Models
{
	[Serializable, DisplayName("Owned Badge")]
    public class BadgeInstance
    {
		[DisplayName("Comment")] public string award_comment { get; set; }
		[DisplayName("Time Stamp")] public DateTime award_timestamp { get; set; }
		[DisplayName("Recipient ID")] public long recipient_id { get; set; } //DO NOT USE, use user_id instead
		[DisplayName("Sender ID")] public long award_sentid { get; set; }
		[DisplayName("Badge ID")] public long badge_id { get; set; }
		public long user_id { get; set; }
		[Key]public long award_id { get; set; } //dont set this, its only for mapping identity keys

		public int award_xcoord { get; set; }
		public int award_ycoord { get; set; }

		public BadgeType badge_type { get; set; }

		public override string ToString() {
			return "{ badge_id:'" + badge_id + "' user_id:'" + user_id + "' award_sentid:'" + award_sentid + "' award_timestamp:'" + award_timestamp + "' comment:'" + award_comment + "'}";
		}
	}
}