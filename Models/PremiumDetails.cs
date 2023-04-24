namespace HorizonPollyC.Models
{
    public class PremiumDetails
    {
        public DateTime? LastBillingDate { get; set; }
        public DateTime? LastPaidDate { get; set; }
        public DateTime? NextBillingDate { get; set; }
        public Decimal? PolicyPremiumAmount { get; set; }
        public Int32? PremiumCount { get; set; }
        public String? PaymentFrequency { get; set; }

    }
}
