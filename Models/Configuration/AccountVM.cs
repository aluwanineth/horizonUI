using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class AccountVM
    {
        [Required]
        public Int16 AccountCD { get; set; }
        [Required]
        public string SDescr { get; set; }
        [Required]
        public string LegacyAccount { get; set; }
        [DataType(DataType.Date)]
        public DateTime EffDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}
