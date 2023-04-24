namespace HorizonPollyC.Models.Financial
{
    public class RegisterAccountAndAccountHolderAccountResultVM
    {
        public Guid Id { get; set; } // This is the AccountHolderAccountId
        public AccountHolderAccountVM Details { get; set; }
        public bool IsNew { get; set; }
        public string Message { get; set; }
    }
}
