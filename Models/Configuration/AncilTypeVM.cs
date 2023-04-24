using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class AncilTypeVM
    {
        [Required]
        public Int16 AncillTypeCd { get; set; }
        [Required]
        public string SDesc { get; set; }
        [Required]
        public DateTime EffDate { get; set; }
        [Required]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}
