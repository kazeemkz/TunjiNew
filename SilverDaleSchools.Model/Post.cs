using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverDaleSchools.Model
{
    public class Post
    {
       
        public int PostID { get; set; }
        [Required]
        public string Title { get; set; }
        public Int32 PosterName { get; set; }
        public string RealName { get; set; }
        public string Role { get; set; }

      //  public string Level { get; set; }
        [Required]
        public string Subject { get; set; }
        //  public DateTime DateCreated { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Article")]
        public string PostBody { get; set; }
        public DateTime DateCreated { get; set; }
       
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
