using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class BenefitPlanIncrsVM
    {
        [Required]
        public int BenefitPlanIncrID { get; set; }
        [Required]
        public int BenefitPlanID { get; set; }
        [Required]
        public int AnnIncCD { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
