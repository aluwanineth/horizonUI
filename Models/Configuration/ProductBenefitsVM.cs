using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class ProductBenefitsVM
    {
        [Required]
        public int ProductBenID { get; set; }
        [Required]
        public Int16 ProductLineCD { get; set; }
        [Required]
        public Int16 BenefitTypeCD { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
