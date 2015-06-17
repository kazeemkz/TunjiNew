using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverDaleSchools.Models
{
    public static class GradeCalculator
    {

        public static string Calculate(decimal theScore)
        {
            string theGrade = "F";
            if(theScore > 70)
            {

                theGrade = "A";
            }

            if (theScore < 70 && theScore >= 60)
            {

                theGrade = "B";
            }

            if (theScore < 60 && theScore >= 50)
            {

                theGrade = "C";
            }

            if (theScore < 50 && theScore >= 40)
            {

                theGrade = "E";
            }

            if (theScore < 40)
            {

                theGrade = "F";
            }
            return theGrade;

        }



        public static string CalculateSenoir(string theScores)
        {

            try
            {
                if (string.IsNullOrEmpty(theScores))
                {
                    return "";
                }
                else
                {
                    decimal theScore = Convert.ToDecimal(theScores);
                    string theGrade = "F";
                    if (theScore > 70)
                    {

                        theGrade = "A";
                    }

                    if (theScore < 70 && theScore >= 60)
                    {

                        theGrade = "B";
                    }

                    if (theScore < 60 && theScore >= 50)
                    {

                        theGrade = "C";
                    }

                    if (theScore < 50 && theScore >= 40)
                    {

                        theGrade = "E";
                    }

                    if (theScore < 40)
                    {

                        theGrade = "F";
                    }
                    return theGrade;
                }

            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}