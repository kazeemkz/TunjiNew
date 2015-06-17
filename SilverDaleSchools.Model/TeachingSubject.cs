using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverDaleSchools.Model
{
  public  class TeachingSubject
    {
      public  int TeachingSubjectID {get;set;}
      public string SubjectName { get; set; }
    //  public ICollection<TeachingDay> TheTeachingDay { get; set; }
     // public virtual TeachingClass TeachingClass { get; set; }
      public virtual TeachingDay TeachingDay { get; set; }

    }
}
