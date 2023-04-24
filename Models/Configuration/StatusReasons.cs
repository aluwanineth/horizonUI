using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonPollyC.Models.Configuration
{
    public class StatusReasons
    {
        [Required]
        public int StatusReasonID { get; set; }
        [Required]

        public Int16 StatusCD { get; set; }
        [Required]

        public Int16 ReasonCD { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EffectiveDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }

        public bool IsActive { get; set; }

    }
}
