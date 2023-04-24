using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class BenefitPlanAncillsVM
    {
        [Required]
        public int BenefitPlanAncillID { get; set; }
        [Required]
        public int BenefitPlanID { get; set; }
        [Required]
        public Int16 RoleCD { get; set; }
        [Required]
        public Int16 AncillBenefitCD { get; set; }
        [Required]
        public Int16 AncillTypeCD { get; set; }
        [Required]
        public Int16 AttributesRequired { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
