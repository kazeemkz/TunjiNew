using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SilverDaleSchools.Model;

namespace  SilverDaleSchools.DAL
{
    public class SubjectRegistrationRepository : GenericRepository<SubjectRegistration>
    {
        public SubjectRegistrationRepository(sdContext context)
            : base(context){}

        public override SubjectRegistration GetByID(object id)
        {
            int theID = Convert.ToInt32(id);
            return context.SubjectRegistrations.Include("Subjects").Where(a => a.SubjectRegistrationID == theID).Single();
           // return dbSet..Include(a=>a.Subjects).Find(id).;
        }

      

    }
}
