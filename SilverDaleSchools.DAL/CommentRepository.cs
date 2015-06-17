using SilverDaleSchools.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverDaleSchools.DAL
{
    public class CommentRepository : GenericRepository<Comment>
    {
        public CommentRepository(sdContext context)
            : base(context)
        {

        }
    }
}
