using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolManagement.DAL;
using SchoolManagement.Model;

namespace SchoolManagement.Models
{
    public class StudentItemViewModel
    {
       // public SubjectRegistration TheSubjectRegistration { get; set; }
        public List<Store> StudentStoreItem { get; set; }
       
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Term { get; set; }
        public string Level { get; set; }
        public decimal TotalCost { get; set; }
    }
}