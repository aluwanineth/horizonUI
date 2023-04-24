using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class LanguageVM
    {
        [Required]
        public byte LanguageCD { get; set; }
        [Required]
        public string SDescr { get; set; }
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
