using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class EventSubscriptionVM
    {
        [Required]
        public int EventSubscriptionCD { get; set; }
        [Required]
        public Int16 EventTypeCD { get; set; }
        [Required]
        public Int16 PartnerCD { get; set; }
        [Required]
        public Int16 EventSubscriberCD { get; set; }
        [Required]
        public Int16 SubscriptionTypeCD { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime LastChanged { get; set; }
        public string UserId { get; set; }
    }
}
