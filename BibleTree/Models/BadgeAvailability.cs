using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace BibleTree.Models
{
    public class BadgeAvailability
    {

        public DateTime start_availability_date { get; set; }
        public DateTime end_availability_date { get; set; }
        public bool has_date_restrictions { get; set; }

    }
}