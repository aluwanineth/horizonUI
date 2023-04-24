namespace HorizonPollyC.Models.Financial
{
    public class RequestMandate
    {
        public int SourceSystemId { get; set; }
        //public string AgentCode { get; set; }
        //public string AgentName { get; set; }
        //public string TeamName { get; set; }
        //public string BusinessDivision { get; set; }
        //public bool Success { get; set; }
        //public string Message { get; set; }
        public string PolicyNumber { get; set; }
        public string ApplicationNumber { get; set; }
        //public int Amount { get; set; }
        //public string BankName { get; set; }
        //public string BankAccountNumber { get; set; }
        //public string BankBranchCode { get; set; }
        //public string BankAccountType { get; set; }
        //public string PayerFirstNames { get; set; }
        //public string PayerSurname { get; set; }
        //public string PayerInitials { get; set; }
        //public string PayerIdentityType { get; set; }
        //public string PayerIdentityNumber { get; set; }
        //public string PayerMobileTelephoneNumber { get; set; }
        //public int DebitDay { get; set; }
        //public string ProductCategory { get; set; }
        //public int TransactionType { get; set; }
        public bool ExistingClient { get; set; }
        //public string PaymentFrequency { get; set; }
        //public string PaymentChannel { get; set; }
    }
}
