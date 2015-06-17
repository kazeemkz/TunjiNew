using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SchoolManagement.Model;
using SilverDaleSchools.Model;

namespace SilverDaleSchools.DAL
{
    public class SubjectRepository : GenericRepository<Subject>
    {
        public SubjectRepository(sdContext context)
            : base(context)
        {




        }
    }
}
