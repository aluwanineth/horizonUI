using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonPollyC.Models.Configuration
{
    public class CountryPhone
    {
        [Required]
        public short CountryPhoneCD { get; set; }
        [Required]
        public String CountryName { get; set; }
        [Required]
        public short PrefixCode { get; set; }
        public byte? NSNLengthMin { get; set; }
        public byte? NSNLengthMax { get; set; }
    }
}
