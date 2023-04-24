using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonPollyC.Models
{
    public  class BenefitDetails
    {
        public int BenefitID { get; set; }
        public string BenefitDesctiption { get; set; }
        public DateTime DOC { get; set; }
        public decimal? CoverAmount { get; set; }
        public string Status { get; set; }
        public decimal Premium { get; set; }
        public string SumAssured { get; set; }
        public bool isActive { get; set; }
    }
}
