using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class LegacyPaymentVM
    {
        [Required]
        public int LegacyPaymentMethodCD { get; set; }
        [Required]
        public string SDesc { get; set; }
        [Required]
        public string SCode { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        public DateTime LastChanged { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EffDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}
