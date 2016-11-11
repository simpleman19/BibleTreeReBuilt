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
		[DisplayName("Recipient ID")] public long recipient_id { get; set; }
		[DisplayName("Sender ID")] public long sender_id { get; set; }
		[DisplayName("Badge ID")] public long badge_id { get; set; }
		public long user_id { get; set; }
		[Key]public long award_id { get; set; }

		public BadgeType badge_type { get; set; }
    }
}