using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class AttendanceViewModel
    {
        public IEnumerable<Attendance> TheAttendance { get; set; }
    }
}