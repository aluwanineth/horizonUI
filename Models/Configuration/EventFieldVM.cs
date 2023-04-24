using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class EventFieldVM
    {
        [Required]
        public int EventFieldCD { get; set; }
        [Required]
        public int EventSubscriptionCD { get; set; }
        [Required]
        public int DataArtefactCD { get; set; }
        [Required]
        public string SQLStatementOverride { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime LastChanged { get; set; }
        public string UserId { get; set; }
    }
}
