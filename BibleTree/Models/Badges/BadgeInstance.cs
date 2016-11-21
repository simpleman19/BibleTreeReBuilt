using System;
using System.ComponentModel;
using Dapper.Contrib.Extensions;

namespace BibleTree.Models
{
	[Serializable, DisplayName("Owned Badge")]
    public class BadgeInstance
    {
		[DisplayName("Comment")] public string comment { get; set; }
		[DisplayName("Time Stamp")] public DateTime time_stamp { get; set; }
		[DisplayName("Recipient ID")] public long recipient_id { get; set; } //use user_id instead
		[DisplayName("Sender ID")] public long award_sentid { get; set; }
		[DisplayName("Badge ID")] public long badge_id { get; set; }
		public long user_id { get; set; }
		[Key]public long award_id { get; set; } //dont set this, its only for mapping identity keys

		public BadgeType badge_type { get; set; }

		public override string ToString() {
			return "{ badge_id:'" + badge_id + "' user_id:'" + user_id + "' sender_id:'" + sender_id + "' time_stamp:'" + time_stamp + "' comment:'" + comment + "'}";
		}
	}
}