using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class PremPortionVM
    {

        [Required]
        public Int16 PremiumPortionID { get; set; }
        [Required]
        public Int16 PremiumPortionCD { get; set; }
        [Required]
        public Int16 SchemeCD { get; set; }
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
        public int BasedOn { get; set; }
        [Required]
        public Int16 ProcessSeq { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }

        public bool IsActive { get; set; }
    }
}
