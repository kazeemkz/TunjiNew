using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SilverDaleSchools.Models
{
    public static class UserIDLengthAdjuster
    {
        public static string NumberAdjuster(string theID)
        {
            StringBuilder build = new StringBuilder();
            int theLength = theID.Length;
            if(theLength ==1)
            {
                build.Append('0');
                build.Append('0');
                build.Append('0');
                build.Append(theID);
            }
            if (theLength == 2)
            {
                build.Append('0');
                build.Append('0');
              //  build.Append('0');
                build.Append(theID);
            }
            if (theLength == 3)
            {
                build.Append('0');
               // build.Append('0');
                //  build.Append('0');
                build.Append(theID);
            }
         return   build.ToString();
        }
    }
}