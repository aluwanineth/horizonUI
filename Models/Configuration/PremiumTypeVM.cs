using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonPollyC.Models.Configuration
{
    public class PremiumTypeVM
    {
        [Required]
        public Int16 PremiumTypeCD { get; set; }
        [Required]
        public string SDesc { get; set; }
        [Required]
        public Int16? DispSeq { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EffDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}

