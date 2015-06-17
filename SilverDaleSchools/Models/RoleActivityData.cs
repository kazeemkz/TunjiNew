using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverDaleSchools.Models
{
    public class RoleActivityDataStudent
    {
        public int ActivityID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }


    public class ActivityData
    {
        public int ActivityID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}