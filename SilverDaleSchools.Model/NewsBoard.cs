using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SilverDaleSchools.Model
{
  public  class NewsBoard
    {
      public int NewsBoardID {get; set;}
      [Required]
     [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long and maximum of 30.", MinimumLength = 6)]
      public string Caption { get; set; }
    //  [UIHint("tinymce_jquery_full"), AllowHtml]
      // [Display(Name = "Ritch Text")]
      [Required]
      [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long and maximum of 500.", MinimumLength = 6)]
      public string Content { get; set; }
      public DateTime Date { get; set; }

    }
}
