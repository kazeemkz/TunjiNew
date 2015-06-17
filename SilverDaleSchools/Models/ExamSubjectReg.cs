using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolManagement.Model;

namespace SchoolManagement.Models
{
    public class ExamSubjectReg
    {
        public SubjectRegistration TheSubjectRegistration { get; set; }
        public List<Exam> TheExam { get; set; }
        public List<Subject> TheSubjects { get; set; }

        public List<Subject> FailedSubjects { get; set; }
        public List<Subject> FailedSubjects2 { get; set; }
        public string StudentID { get; set; }
        public int StudentIDInt { get; set; }
        public int StudentName { get; set; }
        public string StudentClassType { get; set; }
        public string Term { get; set; }
        public string Level { get; set; }
       // public string Session { get; set; }
        public int Repeat { get; set; }
        public decimal? Total { get; set; }
       
    }
}