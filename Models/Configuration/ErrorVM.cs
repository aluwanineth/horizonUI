using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class ErrorVM
    {
        [Required]
        public int ErrorCD { get; set; }
        [Required]
        public string SDesc { get; set; }
        [Required]
        public Int16 DispSeq { get; set; }
        [Required]
        public DateTime EffDate { get; set; }
        [Required]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }

    }
}
