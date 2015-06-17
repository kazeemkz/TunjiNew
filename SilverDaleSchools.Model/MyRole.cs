using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverDaleSchools.Model
{
    public class MyRole
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MyRoleID { get; set; }
        public string RoleName { get; set; }
        public string Student { get; set; }
        public string Subject { get; set; }
        public string ClassSubject { get; set; }
        public string Level { get; set; }
        public string Exam { get; set; }
        public string StudentFees { get; set; }
        public string Store { get; set; }
        public string Staff { get; set; }
        public string OnlineExam { get; set; }
        public string TimeTable { get; set; }
        public string NewsBoard { get; set; }
        public string Parent { get; set; }
        public string BulkSMS { get; set; }
        public string Post { get; set; }
        public string Attendance { get; set; }
        public string AttendanceStaff { get; set; }
        public string OrderItem { get; set; }
        public string SecondarySchoolStudent { get; set; }
        public string SchoolFeePayment {get;set;}
        public string StudentStoreItem { get; set; }
        public string Material { get; set; }

        public string Result { get; set; }
     
    }
}
