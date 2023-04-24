namespace HorizonPollyC.Models.Financial
{
    public class RegisterAccountAndAccountHolderResultVM
    {
        public Guid Id { get; set; } // This is the AccountHolderAccountId
        public bool IsNew { get; set; }
        public string Message { get; set; }
    }
}
