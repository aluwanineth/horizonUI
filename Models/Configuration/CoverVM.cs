using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class CoverVM
    {
        [Required]
        public int CoverID { get; set; }
        [Required]
        public decimal CoverAmt { get; set; }
        [Required]
        public Int16 DispSeq { get; set; }
        [Required]
        public DateTime EffDate { get; set; }
        [Required]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}
