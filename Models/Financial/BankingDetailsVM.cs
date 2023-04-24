namespace HorizonPollyC.Models.Financial
{
    public class BankingDetailsVM
    {
        public string AccountHolder { get; set; }
        // public string BankName { get; set; }
        public int BankId { get; set; }
        // public string AccountType { get; set; }
        public byte AccountTypeId { get; set; }
        public string PaymentMethod { get; set; }
        public int EarlyWEPH { get; set; }
        public int DebitDay { get; set; }
        public string BranchCode { get; set; }
        public string AccountNumber { get; set; }
        public string EarlyTracking { get; set; }
        public string FirstDebitDay { get; set; }
    }
}
