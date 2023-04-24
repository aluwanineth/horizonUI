namespace HorizonPollyC.Models.Financial
{
    public class FinancialDetailsValidationVM
    {
        public string AccountNumber { get; set; }
        public int BranchCode { get; set; }
        public string AccountType { get; set; }
        public string BankName { get; set; }
        public BankValidationOptionsVM BankValidationOptions { get; set; }
    }

    
}
