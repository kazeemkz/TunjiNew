using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverDaleSchools.Model
{
 public   class Comment
    {
     [Key]
     //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CommentID { get; set; }
        public Int32 Commenter { get; set; }
        public string CommenterName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
        public string Role { get; set; }
        public int PostID { get; set; }
         //navigation back to parent
        public virtual Post Post { get; set; }
    }
}
