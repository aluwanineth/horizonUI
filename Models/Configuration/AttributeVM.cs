using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class AttributeVM
    {
        [Required]
        public Int16 AttributeCD { get; set; }
        [Required]
        public string SDesc { get; set; }
        [Required]
        public Int16 DispSeq { get; set; }
        [Required]
        public DateTime EffDate { get; set; }
        [Required]
        public DateTime ExpDate { get; set; }
        [Required]
        public Int16 LevelCD { get; set; }
        [Required]
        public string AttAmmountCode { get; set; }
        [Required]
        public string AttTextCode { get; set; }
        [Required]
        public string LookupTable { get; set; }
        [Required]
        public string LookupKey { get; set; }
        public bool IsActive { get; set; }
    }
}
