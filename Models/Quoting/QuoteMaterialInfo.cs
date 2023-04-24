using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonPollyC.Models.Quoting
{
    public class QuoteMaterialInfoModel
    {
        public int Quote_ID { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public int Gender_CD { get; set; }
        public int InstallmentFrequency { get; set; }
        public Nullable<System.DateTime> EffDate { get; set; }
        public int SmokerStatus { get; set; }
        public int CoverID { get; set; }
    }
}
