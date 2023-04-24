using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class MovementVM
    {
        [Required]
        public Int16 MovementCD { get; set; }
        [Required]
        public string SDesc { get; set; }
        [Required]
        public string LegacyMovementCd { get; set; }
        [Required]
        public Int16 DispSeq { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EffDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}
