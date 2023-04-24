using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class PortionControlVM
    {
        [Key]
        [Required]
        public int PortionCD { get; set; }
        [Required]
        public int PortionGroupCD { get; set; }
        [Required]
        public int PremPortionTypeCD { get; set; }
        [Required]
        public decimal PortionAmount { get; set; }
        [Required]
        public decimal PortionPercentage { get; set; }
        [Required]
        public int BasedOn { get; set; }
        [Required]
        public int ProcessSequence { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EffDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}
