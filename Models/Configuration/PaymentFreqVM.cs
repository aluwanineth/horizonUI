using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class PaymentFreqVM
    {
        [Required]
        public int PaymentFreqCD { get; set; }
        [Required]
        public string ShortDesc { get; set; }
        [Required]
        public int DispSeq { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EffDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}
