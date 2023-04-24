namespace HorizonPollyC.Models.Financial
{
    public class Debicheck
    {
        public CustomerPolicies custPolicies { get; set; }
        public bool Checked { get; set; }
        public int Policy_NO { get; set; }
        public string DebiCheckStatus { get; set; }
        public decimal Amount { get; set; }
        public DateTime CurrentStatusDateTime { get; set; }
        public string BankName { get; set; }

    }
}
