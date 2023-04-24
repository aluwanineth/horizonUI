using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class BenefitPlansVM
    {
        [Required]
        public int BenefitPlanID { get; set; }
        [Required]
        public Int16 BenefitTypeCD { get; set; }
        [Required]
        public Int16 PlanCD { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
