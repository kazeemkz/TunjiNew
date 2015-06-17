using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverDaleSchools.Models
{
    public static class SessionHelper
    {
        //find if a current session is greater than the other
        public static double FindLager(string session, string term)
        {
            string[] theSession = session.Split('/');
           // int theTerm = 0;

            double theYearTerm = Convert.ToInt32(theSession[0]) + Convert.ToInt32(theSession[1]);

            if (term == "First")
            {
              theYearTerm =  theYearTerm + 0.1;
            }
            if (term == "Second")
            {
                theYearTerm = theYearTerm + 0.2;
            }
            if (term == "Third")
            {
                theYearTerm = theYearTerm + 0.3;
            }
            return theYearTerm;
        }
    }
}