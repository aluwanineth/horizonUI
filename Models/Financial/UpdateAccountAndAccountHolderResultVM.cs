namespace HorizonPollyC.Models.Financial
{
    public class UpdateAccountAndAccountHolderResultVM
    {
        public Guid Id { get; set; } // This is the AccountHolderAccountId
        public Guid AccountHolder { get; set; } // This is the AccountHolderId

        public AccountVM Account { get; set; }
    }
}
