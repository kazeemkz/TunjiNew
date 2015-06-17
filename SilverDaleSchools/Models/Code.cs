using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SilverDaleSchools.Models
{
    public class Code
    {
        [Required]
        public string SecretCode { get; set; }
    }
}