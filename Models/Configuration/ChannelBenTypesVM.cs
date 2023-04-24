using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class ChannelBenTypesVM
    {
        [Required]
        public int ChannelBenTypeID { get; set; }
        [Required]
        public Int16 ChannelCD { get; set; }
        [Required]
        public Int16 BenefitTypeCD { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
