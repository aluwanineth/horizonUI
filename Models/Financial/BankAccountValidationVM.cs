namespace HorizonPollyC.Models.Financial
{
    public class BankAccountValidationVM
    {
        public string AccountNumber { get; set; }
        public string BranchCode { get; set; }
        public string AccountType { get; set; }
        public string BankName { get; set; }

        public BankValidationOptionsVM BankValidationOptions { get; set; }
    }
}
