using SilverDaleSchools.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverDaleSchools.Models
{
    
    public class DayHelper
    {
        public static Day GetDay(string day)
        {
            if (day == "SUNDAY")
            {
             return Day.SUNDAY;
            }

            if (day == "MONDAY")
            {
                return Day.MONDAY;
            }

            if (day == "TUESDAY")
            {
                return Day.TUESDAY;
            }

            if (day == "WEDNESDAY")
            {
                return Day.WEDNESDAY;
            }

            if (day == "THURSDAY")
            {
               return Day.THURSDAY;
            }

            if (day == "FRIDAY")
            {
                return Day.FRIDAY;
            }


            if (day == "SATURDAY")
            {
                return Day.SATURDAY;
            }
            return Day.SUNDAY;
        }
    }
}