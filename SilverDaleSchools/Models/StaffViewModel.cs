using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class StaffViewModel
    {
        public PrimarySchoolStaff PrimarySchoolStaff { get; set; }
       // public string Level { get; set; }
        public IList<Deduction> Deductions { get; set; }
    }
}