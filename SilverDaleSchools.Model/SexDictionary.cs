using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SilverDaleSchools.Model
{
    public class SexDictionary
    {
        public static SelectList SexDicoList
        {
            get { return new SelectList(SexDic, "Value", "Key"); }
        }

        private static readonly IDictionary<string, string> SexDic = new Dictionary<string, string> 
       {{"Choose..",""} ,
        {"Male","Male"},
         {"Female","Female"},
             
       };

    }
}

