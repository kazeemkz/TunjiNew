//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SilverDaleSchools.Model
//{
//    public class Staff : Person
//    {

////public int StaffID { get; set; }

       
//        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy  HH:mm:ss}", ApplyFormatInEditMode = true)]
//        [Display(Name = "Enrollment Date")]
//        //[Required, DataType(DataType.Date)]
//        public DateTime EnrollmentDate { get; set; }
       
//        [Display(Name = "Date of Birth")]
//        public DateTime DOB { get; set; }


//        [Display(Name = "Blood Group")]
//        public string BloodGroup { get; set; }

//        public string Genotype { get; set; }
//        [Display(Name = "State Disability if Any")]
//        public string Disability { get; set; }

//        //public bool IsApproved { get; set; }
//       // public string Role { get; set; }

//        //public string CreatedUserName { get; set; }
//       // public string ApprovedUserName { get; set; }
       
//       // [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy  HH:mm:ss}", ApplyFormatInEditMode = true)]
//       // public DateTime? DateApproved { get; set; }
//        //[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy }", ApplyFormatInEditMode = true)]
//       // [Display(Name = "Place Of Birth")]
//       // public string PlaceOfBirth { get; set; }



        


//        [RegularExpression(@"^[0-9]{0,15}$", ErrorMessage = "Telephone Number should contain only numbers")]
//        public string Telephone { get; set; }

//      //  [Display(Name = "Subject Strength")]
//      //  public string SubjectStrength { get; set; }


//      //  [Display(Name = "Class Teacher Of")]
//        //public string ClassTeacherOf { get; set; }
//        //public string Role { get; set; }

//        [Display(Name = "Email Address")]
//        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Email is not in proper format")]
//        [DataType(DataType.EmailAddress)]
//        public string Email { get; set; }


//        //[Display(Name = "Hightest Qualification")]
//        //public string HightestQualification { get; set; }
//    }
//}
