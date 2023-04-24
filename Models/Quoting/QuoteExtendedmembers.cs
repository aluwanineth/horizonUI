using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonPollyC.Models.Quoting
{
    public class QuoteExtendedmembersModel
    {
        public int EntityID { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Relation { get; set; }
        public int RelationID { get; set; }
        public string IDNumber { get; set; }
        public Nullable<decimal> Covered_Amount { get; set; }
        public Nullable<decimal> Premium_Amount { get; set; }
        public string Waiting_Period { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Status { get; set; }
    }
}
