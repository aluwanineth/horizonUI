using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonPollyC.Models.Configuration
{
    public class TakeOnOptionVM
    {
        [Required]
        public Int16 TakeOnOptionCd { get; set; }
        [Required]
        public string ShortDesc { get; set; }
        [Required]
        public decimal BenefitChangePerc { get; set; }
        [Required]
        public decimal PremiumChangePerc { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EffDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}
