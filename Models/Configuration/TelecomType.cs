using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonPollyC.Models.Configuration
{
    public class TelecomType
    {
        [Required]
        public short TelTypeCD { get; set; }
        public String CountryCode { get; set; }
        [Required]
        public String TelTypeCode { get; set; }
        [Required]
        public String TelTypeDesc { get; set; }
        public String TelTypeRegEx { get; set; }
        public short? DispSeq { get; set; }
        [Required]
        public Boolean IsActive { get; set; }
    }
}
