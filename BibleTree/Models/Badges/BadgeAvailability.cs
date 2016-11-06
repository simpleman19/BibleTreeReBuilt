using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace BibleTree.Models
{
	[Serializable, DisplayName("Badge Availability")]
    public class BadgeAvailability
    {
		[DisplayName("Beginning Badge Date")] public DateTime start_availability_date { get; set; }
		[DisplayName("Final Badge Date")] public DateTime end_availability_date { get; set; }
		[DisplayName("Restrictions")] public bool has_date_restrictions { get; set; }
		
		[DisplayName("Badge Availability")]
        public bool is_available
        {
            get
            {
                if (!has_date_restrictions)
                { return true; }
                else if (DateTime.Compare(DateTime.Now, start_availability_date) >= 0 && DateTime.Compare(DateTime.Now, end_availability_date) < 0)
                { return true; }
                else { return false; }
            }
        }

		/*
        public BadgeAvailability(bool has_date_restrictions,
                            DateTime start_availability_date,
                            DateTime end_availability_date)
        {
            this.has_date_restrictions = has_date_restrictions;
            this.end_availability_date = end_availability_date;
            this.start_availability_date = start_availability_date;
        }
		*/
    }
}