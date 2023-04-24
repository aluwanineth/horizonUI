using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class EventHeaderVM
    {
        [Required]
        public int EventHeaderCD { get; set; }
        [Required]
        public int EventSubscriptionCD { get; set; }
        [Required]
        public string EventHeaderConstruct { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime LastChanged { get; set; }
        public string UserId { get; set; }
    }
}
