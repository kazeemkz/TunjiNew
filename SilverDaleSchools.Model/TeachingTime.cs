using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverDaleSchools.Model
{
  public  class TeachingTime
    {
      public int TeachingTimeID { get; set; }


      [Required]
      public string StratTimeHour { get; set; }

      [Required]
      public string StratTimeMinute { get; set; }
      [Required]
      public string EndTimeHour { get; set; }
     
      [Required]
      public string EndTimeMinute { get; set; }

    //  public string startingTime { get; set; }
   //   public string stopingTime { get; set; }
    //  public  Virtual TeachingSubject> TheTeachingSubject
     // public virtual TeachingDay TeachingDay { get; set; }

    }
}
