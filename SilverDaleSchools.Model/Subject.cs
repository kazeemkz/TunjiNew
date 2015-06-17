using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SilverDaleSchools.Model
{
    public class Subject
    {
        [Key]
      //  [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubjectID { get; set; }
        //  public string IsSubjectNameExists(string Name)
       //[Remote("IsSubjectNameExists", "Subject", ErrorMessage="Can't Add What Already Exist")]
       // [Required]
        public string Name { get; set; }

        [Required]
        public string Level { get; set; }


       
        //[Required]
        [Range(typeof(decimal),"0.0","60.0")]
      //  [Required]
        [Display(Name = " Exam")]
        public decimal? SubjectExam { get; set; }
       [Range(typeof(decimal), "0.0", "20.0")]
      // [Required]
           [Display(Name=" Test 1")]
        public decimal? FirstCA { get; set; }
       [Range(typeof(decimal), "0.0", "20.0")]
       //[Required]
       [Display(Name = " Test 2")]
        public decimal? SecondCA { get; set; }
          [Range(typeof(decimal), "0.0", "100.0")]
        public decimal? Total { get; set; }
        //  public string StudentCode { get; set; }

          public ICollection<SubjectRegistration> SubjectRegistration { get; set; }

        [NotMapped]
        public bool Selected { get; set; }

    }
}
