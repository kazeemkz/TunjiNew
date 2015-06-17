using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverDaleSchools.Model
{
   public class Teacher
    {
       public int TeacherID { get; set; }
       public string TeacherName { get; set; }
       public ICollection<TeachingClass> TheTeachingClass { get; set; }
       public int ThePersonID { get; set; }
    }
}
