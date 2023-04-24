using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class BenefitOptionsVM
    {
        [Required]
        public int BenefitOptionID { get; set; }
        [Required]
        public Int16 BenefitTypeCD { get; set; }
        [Required]
        public Int16 BenefitOptionCD { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }

        public bool IsActive { get; set; }
    }
}
