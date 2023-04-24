namespace HorizonPollyC.Models.Financial
{
    public class AccountVM
    {
        public Guid Id { get; set; }
        public Guid AccountHash { get; set; }

        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string BranchCode { get; set; }
        public string AccountType { get; set; }
        public string MaskedAccountNumber { get; set; }

        public byte[] EncryptedAccount { get; set; }
    }
}
