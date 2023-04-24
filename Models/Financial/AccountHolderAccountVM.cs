namespace HorizonPollyC.Models.Financial
{
    public class AccountHolderAccountVM
    {
        public Guid Id { get; set; }
        public AccountVM Account { get; set; }
        public AccountHolderVM AccountHolder { get; set; }
    }
}
