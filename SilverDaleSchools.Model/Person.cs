using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remotion.Data.Linq;
//using LinqToExcel;
//using LinqToExcel.Attributes;

namespace SilverDaleSchools.Model
{
    public class Person
    {
        public int PersonID { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [Required]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        [Required]

        // [ExcelColumn("Student Number")]
        [Display(Name = "Staff/Student ID")]
        public int UserID { get; set; }

      //  public ICollection<Subject> Subjects { get; set; }

        //  [ExcelColumn("Surname")]
        // [Display(Name = "Middle Name")]
         [Required]
        // [Range(0.0, 20.0)]
         public string Password { get; set; }

        // [Display(Name = "Last Name")]
        // [Required]
        //// [ExcelColumn("Lastname")]
        // public string LastName { get; set; }


        // [Required]
        // [ExcelColumn("sex")]
        public string Sex { get; set; }

        [Display(Name = "Current Level")]
        public string Level { get; set; }


        [Required]
        public string Role { get; set; }
    }
}
