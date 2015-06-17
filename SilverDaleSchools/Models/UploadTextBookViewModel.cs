using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class UploadTextBookViewModel
    {
        [Required]
        public string Level { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
       // [RegularExpression(@"(\S)+", ErrorMessage = "White Space is Not Allowed, Use - to Seperate Words")]
        public string TextBookTitle { get; set; }

    }
}