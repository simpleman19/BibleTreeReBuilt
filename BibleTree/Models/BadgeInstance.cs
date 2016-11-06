using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibleTree.Models
{
    public class BadgeInstance
    {
        public string comment { get; set; }
        public DateTime time_stamp { get; set; }
        public long recipient_id { get; set; }
        public long sender_id { get; set; }
        public long badge_id { get; set; }
    }
}