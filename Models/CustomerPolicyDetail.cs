using System;

namespace HorizonPollyC.Models
{
    public class CustomerPolicyDetail
    {
        public int Policy_NO { get; set; }
        public int? Entity_NO { get; set; }
        public string Legacy_Pol_No { get; set; }
        public Decimal? Policy_Premium { get; set; }
        public string AnnualIncrease { get; set; }
        public DateTime? Date_of_Commencement { get; set; }
        public DateTime ReInstatedDate { get; set; }
        public DateTime LapsedDate { get; set; }
        public string Venue { get; set; }
        public string SalesPerson { get; set; }
        public int CampaignCode { get; set; }
        public int PolicyFee { get; set; }
        public DateTime CaptureDate { get; set; }
        public string PreferedCommunicationMethod { get; set; }
    }
}
