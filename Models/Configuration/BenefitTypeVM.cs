using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class BenefitTypeVM
    {
        [Required]
        public Int16 BenefitTypeCD { get; set; }
        [Required]
        public string SDesc { get; set; }
        [Required]
        public string LegacyBenCd { get; set; }
        [Required]
        public Int16 AncillOnly { get; set; }
        [Required]
        public Int16 DispSeq { get; set; }
        [Required]
        public Int16 PremiumYN { get; set; }
        [Required]
        public Int16 RateTableCD { get; set; }
        [Required]
        public Int16 CoverYN { get; set; }
        [Required]
        public Int16 ReinsureYN { get; set; }
        [Required]
        public DateTime EffDate { get; set; }
        [Required]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}
