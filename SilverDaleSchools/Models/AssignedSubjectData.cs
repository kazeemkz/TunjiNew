using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverDaleSchools.Models
{
    public class AssignedSubjectData
    {
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}