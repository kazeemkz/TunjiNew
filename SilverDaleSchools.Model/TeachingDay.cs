using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverDaleSchools.Model
{
  public class TeachingDay
    {
      public int TeachingDayID { get; set; }

      public Day theDay {get;set;}
      public ICollection<TeachingSubject> TeachingSubject { get; set; }
      public virtual TeachingClass TeachingClass { get; set; }

      public int TeachingClassID { get; set; }

      [Required]
      public string StratTimeHour { get; set; }

      [Required]
      public string StratTimeMinute { get; set; }
      [Required]
      public string EndTimeHour { get; set; }

      [Required]
      public string EndTimeMinute { get; set; }
    }
}
