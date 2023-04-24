using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class SchemePlanFactorsVM
    {
        [Required]
        public Int16 SchemePlanPremFactorID { get; set; }
        [Required]
        public Int16 SchemeCd { get; set; }
        [Required]
        public Int16 PlanTypeCD { get; set; }
        [Required]
        public Int16 LevelCD { get; set; }
        [Required]
        public Int16 PremPortionTypeCD { get; set; }
        [Required]
        public Decimal PremPortionAmt { get; set; }
        [Required]
        public Decimal PremPortionPerc { get; set; }
        [Required]
        public short BasedOn { get; set; }
        [Required]
        public Int16 ProcessSeq { get; set; }
        [Required]
        public Decimal NBCommFactor { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }

        public bool IsActive { get; set; }
    }
}
