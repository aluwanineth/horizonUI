namespace HorizonPollyC.Models.Financial
{
    public class PolicyToBankAccountVM
    {
        public int EntityId { get; set; }
        public int PolicyNumber { get; set; }
        public int BankAccID { get; set; }
        public int PaymentMethodId { get; set; }
        public string UserID { get; set; }
    }
}
