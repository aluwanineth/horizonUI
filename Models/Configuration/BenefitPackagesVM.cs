using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class BenefitPackagesVM
    {
        [Required]
        public int BenPackID { get; set; }
        [Required]
        public Int16 BenefitTypeCD { get; set; }
        [Required]
        public Int16 BenefitPackageCD { get; set; }
        [Required]
        public DateTime EffDate { get; set; }
        [Required]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}
