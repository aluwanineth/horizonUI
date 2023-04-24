namespace HorizonPollyC.Models.Financial
{
    public class RegisterAccountAndAccountHolder
    {
        public Guid Id { get; set; } // This is the AccountHolderAccountId
        public bool IsNew { get; set; }
        public string Message { get; set; }
    }
}
