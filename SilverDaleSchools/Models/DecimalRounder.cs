using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverDaleSchools.Models
{
    public static class DecimalRounder
    {

        public static string RoundDecimal(string theDecimal)
        {
            try
            {
                if (!(string.IsNullOrEmpty(theDecimal)))
                {
                    decimal theDecimalNumber = Convert.ToDecimal(theDecimal);

               return     Convert.ToString(Math.Round(theDecimalNumber, 2));

                }

                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                return "";
            }
            
        }
    }
}