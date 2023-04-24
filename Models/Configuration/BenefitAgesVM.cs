using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class BenefitAgesVM
    {
        [Required]
        public int BenefitEntryID { get; set; }
        [Required]
        public Int16 BenefitTypeCD { get; set; }
        [Required]
        public Int16 EntryAgeCD { get; set; }
        [Required]
        public Int16 ExpiryAgeCD { get; set; }
        [Required]
        public DateTime EffDate { get; set; }
        [Required]
        public DateTime ExpDate { get; set; }

        public bool IsActive { get; set; }
    }
}
