using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class UploadLessonNoteViewModel
    {
        [Required]
        public string Level {get; set;}
        [Required]

        public string Subject { get; set; }
        [Required]
        public string Chapter { get; set; }
        [Required]
        [Display(Name="Topic Title")]
       // [RegularExpression(@"(\S)+", ErrorMessage = "White Space is Not Allowed, Use - to Seperate Words")]
        public string TopicTitle { get; set; }
      //  [Required, FileExtensions(ErrorMessage = "Specify a doc file")]
        //public HttpPostedFileBase  File { get; set; }

    }
}