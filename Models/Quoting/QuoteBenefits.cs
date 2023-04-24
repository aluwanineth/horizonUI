using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonPollyC.Models.Quoting
{
    public class QuoteBenefits
    {
        public Int16? Status { get; set; }
        public int Benefit_Type_CD { get; set; }
        public string S_Desc { get; set; }
        public decimal? Benefit_Cover { get; set; }
        public decimal? Benefit_Premium { get; set; }
        public int Benefit_Plan_ID { get; set; }
        public DateTime Date_of_Commencement { get; set; }
        public int? Plan_CD { get; set; }
        public short? DisplSeq { get; set; }
    }
}
