using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class StatusReasonsVM
    {
        [Required]
        public int StatusReasonID { get; set; }
        [Required]

        public Int16 StatusCD { get; set; }
        [Required]

        public Int16 ReasonCD { get; set; }
        [Required]

        public DateTime EffectiveDate { get; set; }
        [Required]

        public DateTime ExpiryDate { get; set; }

        public bool IsActive { get; set; }
    }
}
