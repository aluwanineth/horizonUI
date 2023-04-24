using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class EventTypeVM
    {
        [Required]
        public Int16 EventTypeCD { get; set; }
        [Required]
        public string EventTypeCode { get; set; }
        [Required]
        public string EventTypeDescr { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime LastChanged { get; set; }
        public string UserId { get; set; }
    }
}
