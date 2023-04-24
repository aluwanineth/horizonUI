using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class TransTypeVM
    {
        [Required]
        public Int16 TransTypeCD { get; set; }
        [Required]
        public string SDesc { get; set; }
        [Required]
        public string PolDRCR { get; set; }

        public bool IsActive { get; set; }
    }
}
