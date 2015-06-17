using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SilverDaleSchools.Models
{
    public class TimeTable
    {
        [Required]
        public string Class { get; set; }
        [Required]
        [Display(Name = "Starting Hour")]
        public string StratTimeHour { get; set; }
        [Required]
        [Display(Name = "Ending Hour")]
        public string EndTimeHour { get; set; }
        [Required]
        [Display(Name = "Starting Minute")]
        public string StratTimeMinute { get; set; }
        [Required]
        [Display(Name = "Ending Minute")]
        public string EndTimeMinute { get; set; }
        [Required]
        public string EndTime { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Day { get; set; }
        [Required]
        public string Teacher { get; set; }

        public int TeachingSubjectID { get; set; }
        //public string TeacherID { get; set; }
    }
}