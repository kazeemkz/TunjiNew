using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class UploadAdditionalChapterMaterial
    {
        [Required]
        public string Level { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Chapter { get; set; }
       // [Required]
       // [Display(Name = "Topic Title")]
        public string TopicTitle { get; set; }
       // [RegularExpression(@"(\S)+", ErrorMessage = "White Space is Not Allowed, Use - to Seperate Words")]
        [Display(Name = "Material Title")]
        [Required]
        public string MaterialTitle { get; set; }
    }
}