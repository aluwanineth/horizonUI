using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonPollyC.Models.Configuration
{
    public class SchemeVM
    {
        [Required]
        public Int16 SchemeCD { get; set; }

        [Required]
        public Int16 PartnerCD { get; set; }
        [Required]
        public string SDesc { get; set; }
        [Required]
        public int? DispSeq { get; set; }
        [Required]
        public string SourceDesc { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? EffDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}
