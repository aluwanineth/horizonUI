using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class LoadingTypeVM
    {
        [Required]
        public Int16 LoadingTypeCD { get; set; }
        [Required]
        public string SDesc { get; set; }
        [Required]
        public Int16 LevelCD { get; set; }
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
