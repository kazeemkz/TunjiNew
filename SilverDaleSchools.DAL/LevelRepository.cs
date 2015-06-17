using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SilverDaleSchools.DAL;
using SilverDaleSchools.Model;

namespace SilverDaleSchool.DAL
{
    public class LevelRepository : GenericRepository<Level>
    {
        public LevelRepository(sdContext context)
            : base(context)
        {

        }

    }
}
