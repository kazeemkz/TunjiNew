using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class PrimarySchoolStudentViewModel
    {
        public IEnumerable<PrimarySchoolStudent> Item { get; set; }
    }
}