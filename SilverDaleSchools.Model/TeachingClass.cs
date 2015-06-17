using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverDaleSchools.Model
{
 public   class TeachingClass
    {
     public int TeachingClassID { get; set; }
     public string ClassName { get; set; }
   //  public ICollection<TeachingSubject> TheTeachingSubject { get; set; }
     public ICollection<TeachingDay> TheTeachingDay { get; set; }
     public virtual Teacher Teacher { get; set; }
     public int TeacherID  { get; set; }
    }
}
