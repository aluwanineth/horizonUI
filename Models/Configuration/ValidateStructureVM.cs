using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{

    public class ValidateStructureVM
    {
        [Required]
        public int ValidateRuleID { get; set; }
        [Required]
        public Int16 LevelCD { get; set; }
        [Required]
        public Int16 TableID { get; set; }
        [Required]
        public int DataItemCD { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        [Required]
        public string AudUser { get; set; }
        [Required]
        public DateTime AudDate { get; set; }

        public bool IsActive { get; set; }
    }
}
