using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class DiscountVM
    {
        [Required]
        public Int16 DiscountCD { get; set; }
        [Required]
        public Int16 DiscountTypeCD { get; set; }
        [Required]
        public string SDescr { get; set; }
        [Required]
        public decimal DiscountAmt { get; set; }
        [Required]
        public decimal DiscountPerc { get; set; }
        [Required]
        public Int16 DispSeq { get; set; }
        [Required]
        public DateTime EffDate { get; set; }
        [Required]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}
