using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverDaleSchools.Models
{
    public class ResultModel//: IEqualityComparer<decimal>
    {

        public string Subject { get; set; }
        public decimal FirstCA { get; set; }
        public decimal SecondCA { get; set; }
        public decimal Exam { get; set; }
        public decimal Aggregate { get; set; }
        public string LastTerm { get; set; }
        public string Cummulative { get; set; }
        public decimal ClassAverage { get; set; }
        public int Position { get; set; }
        public string Grade { get; set; }
        public List<decimal> TheClassGrades { get; set; }

        //public bool Equals(decimal one, decimal two)
        //{
        //    return StringComparer.InvariantCultureIgnoreCase.Compare(one.)
        //}


    }
}