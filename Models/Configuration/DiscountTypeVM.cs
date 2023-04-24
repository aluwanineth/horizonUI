using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class DiscountTypeVM
    {
        [Required]
        public int DiscountTypeCD { get; set; }
        [Required]
        public string SDesc { get; set; }
        [Required]
        public Int16 LevelCD { get; set; }
        [Required]
        public Int16 DispSeq { get; set; }
        [Required]
        public DateTime EffDate { get; set; }
        [Required]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}
