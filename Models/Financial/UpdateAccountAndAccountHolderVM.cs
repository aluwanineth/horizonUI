namespace HorizonPollyC.Models.Financial
{
    public class UpdateAccountAndAccountHolderVM
    {
        public Guid AccountHolderAccountId { get; set; }
        public Guid AccountHolderId { get; set; }

        public AccountVM BankAccount { get; set; }//??
     

        public string BankName { get; set; }

        public UpdateAccountHolderVM AccountHolder { get; set; }

        public BankValidationOptionsVM BankValidationOptions { get; set; }
    }
}
