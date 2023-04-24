using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class BenefitPlanCoversVM
    {
        [Required]
        public int BenefitPlanCoverID { get; set; }
        [Required]
        public Int32 BenefitPlanID { get; set; }
        [Required]
        public Int32 CoverID { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
