using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolManagement.Model;

namespace SchoolManagement.Models
{
    public class StudentFeeViewModel
    {
        // public IEnumerable<Instructor> Instructors { get; set; }
        public string Term { get; set; }
        public string LastName { get; set; }
        public string Level { get; set; }
        public List<StudentFees> StudentFees { get; set; }





        public decimal TotalCost
        {
            get
            {
                decimal theTotal = 0;
                foreach (var fee in StudentFees)
                {
                    theTotal = theTotal + fee.Cost;
                }

                return theTotal;
            }
        }
    }
}