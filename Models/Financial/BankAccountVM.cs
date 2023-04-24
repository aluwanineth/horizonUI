namespace HorizonPollyC.Models.Financial
{
    public class BankAccountVM
    {
        public int EntityNo { get; set; }
        public int BankAccountID { get; set; }
        public int DebitDay { get; set; }
        public string PaymentMethod { get; set; }
        public string BankAccHolder { get; set; }
        public int BankID { get; set; }
        public int BankAccountTypeCD { get; set; }
        public string BankAccBranchCode { get; set; }
        public string BankAccNo { get; set; }
        public DateTime EffFrom { get; set; }
        public DateTime EffTo { get; set; }
        public DateTime AudModDate { get; set; }
        public string AudModUser { get; set; }
    }
}
