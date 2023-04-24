namespace HorizonPollyC.Models.Financial
{
    public class RegisterAccountAndCreateAccountHolderAccountVM
    {
        public Guid AccountHolderId { get; set; }

        public string BankName { get; set; }
        public string BranchCode { get; set; }
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }

        public BankValidationOptionsVM BankValidationOptions { get; set; }
    }
}
