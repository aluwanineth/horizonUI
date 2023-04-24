namespace HorizonPollyC.Models.Financial
{
    public class PolicyToDebitDaysVM
    {
        public short FirstDebitDay { get; set; }
        public int EntityId { get; set; }
        public int PolicyNumber { get; set; }
        public int BankAccID { get; set; }
        public string UserID { get; set; }
    }
}
