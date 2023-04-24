using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonPollyC.Models.Configuration
{
    public class ScheneLoadLinkVM
    {
        [Required]
        public int SchemeLinkCD { get; set; }
        [Required]
        public string SchemeDesc { get; set; }
        [Required]
        public int SchemeCD { get; set; }
        [Required]
        public string SchemeName { get; set; }
        [Required]
        public Int16? PlanCD { get; set; }
        [Required]
        public string PlanDesc { get; set; }
        //public DateTime EffDate { get; set; }
        //public DateTime ExpDate { get; set; }
        //public bool IsActive { get; set; }
    }
}
