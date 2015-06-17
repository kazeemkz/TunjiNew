using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SilverDalesSchools.Models
{
    public static class PaddPassword
    {
        public static string Padd(string thePassword)
        {
            string theP = thePassword;
            StringBuilder theBuilder = new StringBuilder();
            theBuilder = theBuilder.Append(theP);

            if (theBuilder.Length == 5)
            {
                theBuilder = theBuilder.Append('a');
            }
            if (theBuilder.Length == 4)
            {
                theBuilder = theBuilder.Append('a');
                theBuilder = theBuilder.Append('a');
            }
            if (theBuilder.Length == 3)
            {

                theBuilder = theBuilder.Append('a');
                theBuilder = theBuilder.Append('a');
                theBuilder = theBuilder.Append('a');
            }
            if (theBuilder.Length == 2)
            {

                theBuilder = theBuilder.Append('a');
                theBuilder = theBuilder.Append('a');
                theBuilder = theBuilder.Append('a');
                theBuilder = theBuilder.Append('a');
            }
            if (theBuilder.Length == 1)
            {

                theBuilder = theBuilder.Append('a');
                theBuilder = theBuilder.Append('a');
                theBuilder = theBuilder.Append('a');
                theBuilder = theBuilder.Append('a');
                theBuilder = theBuilder.Append('a');
            }
            return theBuilder.ToString();
        }
    }
}