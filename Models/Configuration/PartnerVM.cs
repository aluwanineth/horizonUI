using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class PartnerVM
    {
        [Required]
        public Int16 PartnerCD { get; set; }
        [Required]
        public string PartnerCode { get; set; }
        [Required]
        public string PartnerDesc { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime LastChanged { get; set; }
        [Required]
        public string UserId { get; set; }
        public string BrandCode { get; set; }
    }
}
