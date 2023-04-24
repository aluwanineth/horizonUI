using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class EventSubscriberVM
    {
        [Required]
        public Int16 EventSubscriberCD { get; set; }
        [Required]
        public string EventSubscriberCode { get; set; }
        [Required]
        public string EventSubscriberDesc { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime LastChanged { get; set; }
        public string UserId { get; set; }
    }
}
