using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class PremiumPortionTypeVM
    {
        [Required]
        public Int16 PremPortionTypeCD { get; set; }
        [Required]
        public string SDesc { get; set; }
        [Required]
        public string AccountCD { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EffDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}
