using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace BibleTree.Models
{
    public class BadgeType
    {
        public enum Badge_Level { CORE, COMPETENCY, COMMENDATION }
        [DisplayName("Name")]
        public string name { get; set; }
        [DisplayName("Still Image Url")]
        public string png_url { get; set; }
        [DisplayName("Animation Url")]
        public string gif_url { get; set; }
        [DisplayName("Description of Badge")]
        public string description { get; set; }
        [DisplayName("Id Number")]
        public long unique_id { get; set; }

        public BadgeAvailability Availability { get; set; }

        public Badge_Level badge_level { get; set; }

    }
}