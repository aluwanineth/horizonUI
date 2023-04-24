using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class GenderVM
    {
        [Required]
        public Int16 GenderCD { get; set; }
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
