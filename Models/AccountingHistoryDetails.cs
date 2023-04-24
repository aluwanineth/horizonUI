namespace HorizonPollyC.Models
{
    public class AccountingHistoryDetails
    {
        public int ReferenceNo { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime PostDate { get; set; }
        public string Status { get; set; }
        public string Tracking { get; set; }
        public decimal AmountBilled { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal AmountOutstanding { get; set; }
    }
}
