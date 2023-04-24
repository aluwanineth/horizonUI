using System;

namespace HorizonPollyC.Models
{
    public class CustomerPolicies
    {
        public int Policy_NO { get; set; }
        public int IFA_No { get; set; }
        public string Product { get; set; }
        public string Policy_Status { get; set; }
        public System.DateTime Status_Date { get; set; }
        public System.DateTime DOC { get; set; }
        public string Payer { get; set; }
        public Nullable<decimal> Policy_Premium { get; set; }
        public System.DateTime Billed_to { get; set; }
        public System.DateTime Paid_to { get; set; }
        public Nullable<int> Premium_Count { get; set; }
        public int Premium_Frequency { get; set; }
        public string Sales_Person { get; set; }
        public string DebiCheck_Status { get; set; }
        public int EntityID { get; internal set; }
    }

}
