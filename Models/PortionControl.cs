using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonPollyC.Models
{

    public class PortionControl
    {     
        public int PortionCD { get; set; }
        public int PortionGroupCD { get; set; }
        public int PremPortionTypeCD { get; set; }
        public decimal? PortionAmount { get; set; }
        public decimal? PortionPercentage { get; set; }
        public int BasedOn { get; set; }
        public int ProcessSequence { get; set; }
        public DateTime EffDate { get; set; }
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}


