using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class BillPeriodVM
    {
        [Required]
        public Int16 BillPeriodCD { get; set; }
        [Required]
        public string AudCreateUser { get; set; }
        [Required]
        public DateTime AudCreateDate { get; set; }
        [Required]
        public DateTime BillPeriodDate { get; set; }
    }
}
