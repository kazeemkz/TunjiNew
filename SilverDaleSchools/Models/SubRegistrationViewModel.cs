using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SilverDaleSchools.Model;

namespace SilverDaleSchools.Models
{
    public class SubRegistrationViewModel
    {
        public SubjectRegistration SubjectRegistration { get; set; }
        public string UserID { get; set; }
       // public Person Person { get; set; }
        public IList<Subject> Subjects { get; set; }
    }
}