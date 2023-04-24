using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class AnnIncFactorsVM
    {
        [Required]
        public Int16 AnnIncCd { get; set; }
        [Required]
        public decimal PremiumIncPerc { get; set; }
        [Required]
        public decimal BenefitIncPerc { get; set; }
        [Required]
        public DateTime EffDate { get; set; }
        [Required]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}
