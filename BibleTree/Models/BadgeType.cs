using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibleTree.Models
{
    public class BadgeType
    {
        public enum Badge_Level { CORE, COMPETENCY, COMMENDATION }

        public string name { get; set; }
        public string png_url { get; set; }
        public string gif_url { get; set; }
        public string description { get; set; }
        public long unique_id { get; set; }
        public BadgeAvailability availability { get; set; }
        public Badge_Level badge_level { get; set; }

    }
}