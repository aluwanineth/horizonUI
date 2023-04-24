namespace HorizonPollyC.Models.Financial
{
    public class RegisterAccountHolderResultVM
    {
        public Guid Id { get; set; } // This is the AccountHolderId
        public bool IsNew { get; set; }
        public string Message { get; set; }
    }
}
