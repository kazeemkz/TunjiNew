using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverDaleSchools.Models
{
    public class Approximation
    {

        public string ShortenSubjectName(string theSubjectName)
        {
            if (theSubjectName == "Basic Science And Technology")
            {
                return "B.S.T";
            }

            if (theSubjectName == "Agricultural Science")
            {
                return "Agric. Science";
            }

            if (theSubjectName == "Culture And Creative Art")
            {
                return "C.C.A";
            }

            if (theSubjectName == "Christian Religious Knowledge")
            {
                return "C.R.K";
            }

            if (theSubjectName == "Physical And Health Education")
            {
                return "P.H.E";
            }

            if (theSubjectName == "Literature In English")
            {
                return "Lit. In English";
            }

            if (theSubjectName == "Further Mathematics")
            {
                return "Further Maths";
            }

            if (theSubjectName == "Financial Accounting")
            {
                return "Fin. Accounting";
            }

            else
            {
                return theSubjectName;
            }
           

        }

        public string ApproximationMethod(decimal theDecimal)
        {
            decimal inputValue = Math.Round(theDecimal, 2);
            string theDecimalString = Convert.ToString(inputValue);
            string theNewString;

         int theLength =   theDecimalString.Length;

         //if (theLength <= 4)
         //{
         //    theNewString = "0" + theDecimalString;

         //    return theNewString;
         //}
         //else
         //{
         //    return theDecimalString;
         //}
         return theDecimalString;

        }

        public string ApproximationMethod2(decimal theDecimal)
        {
            decimal inputValue = Math.Round(theDecimal, 2);
            string theDecimalString = Convert.ToString(inputValue);
            string theNewString = theDecimalString;

            int theLength = theDecimalString.Length;

            //while (theLength < 6)
            //{
            //    theNewString = "0" + theNewString;

            //    theLength = theLength + 1;
            //}
            return theNewString;
            //else
            //{
            //    return theDecimalString;
            //}


        }

        public string ApproximationMethodString(string theString)
        {
            if (theString == "    ")
            {
                return theString;
            }  
            if (theString == "")
            {
                return theString;
            }

            if (theString == null)
            {
                return theString;
            }

            if (String.IsNullOrEmpty(theString))
            {
                return theString;
            }
         //   decimal inputValue = Math.Round(theDecimal, 2);
            string theDecimalString = theString;// Convert.ToString(inputValue);
            string theNewString = theDecimalString;

            int theLength = theDecimalString.Length;

            //while (theLength < 5)
            //{
            //    theNewString =  theNewString +"0";

            //    theLength = theLength + 1;
            //}
            return theNewString;
            //else
            //{
            //    return theDecimalString;
            //}


        }
    }
}