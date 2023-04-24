using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class PortionOptionVM
    {
        [Required]
        public int SchemeCD { get; set; }
        [Required]
        public int PlanCD { get; set; }
        [Required]
        public int OptionCD { get; set; }
        [Required]
        public int PremiumPortionCD { get; set; }
        [Required]
        public int LevelCD { get; set; }
        [Required]
        public int PortionGroupCD { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EffDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}
