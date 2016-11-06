using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibleTree.Models
{
    public class BadgeType
    {
        public enum Badge_Level { CORE, COMPETENCY, COMMENDATION }

        public string Name { get; set; }

        public string png_url { get; set; }

        public string gif_url { get; set; }

        public string Description { get; set; }

        public long Id_Num { get; set; }

        public BadgeAvailability Availability { get; set; }

        public Badge_Level Badge_level { get; set; }

    }
}