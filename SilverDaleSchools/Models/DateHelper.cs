using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverDaleSchools.Models
{
    public class DateHelper
    {
        public static DateTime NigeriaTime(DateTime theTime)
        {
            TimeZoneInfo info = TimeZoneInfo.FindSystemTimeZoneById("W. Central Africa Standard Time");
            DateTimeOffset theOldDate = TimeZoneInfo.ConvertTime(DateTime.Now, info);

            string stringDate = Convert.ToString(theOldDate);
            DateTime theDate = Convert.ToDateTime(stringDate);

            return theDate;
        }
    }
}