using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class StudentFeePaymentViewModel
    {
        public int StudentFeesID { get; set; }
        public string Level { get; set; }
        //  [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        public int StudentID { get; set; }
        public decimal Cost { get; set; }
        public bool Assigned { get; set; }

    }
}