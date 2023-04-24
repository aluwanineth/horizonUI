using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class BenefitPremFreqsVM
    {
        [Required]
        public int BenefitPremFreqID { get; set; }
        [Required]
        public Int16 BenefitTypeCD { get; set; }
        [Required]
        public Int16 PremFreqCD { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
