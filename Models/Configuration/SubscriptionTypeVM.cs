using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonPollyC.Models.Configuration
{
    public class SubscriptionTypeVM
    {
        [Required]
        public Int16 SubscriptionTypeCD { get; set; }
        [Required]
        public string SubscriptionTypeCode { get; set; }
        [Required]
        public string SubscriptionTyeDesc { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime LastChanged { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
