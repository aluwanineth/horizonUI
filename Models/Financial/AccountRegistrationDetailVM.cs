namespace HorizonPollyC.Models.Financial
{
    public class AccountRegistrationDetailVM
    {
        public Guid AccountHolderAccountId { get; set; }
        public AccountVM Account { get; set; }
        public AccountHolderVM AccountHolder { get; set; }
    }
}
