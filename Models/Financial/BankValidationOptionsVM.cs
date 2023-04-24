namespace HorizonPollyC.Models.Financial
{
    public class BankValidationOptionsVM
    {
        public string SourceSystemId { get; set; }
        public bool IsLegal { get; set; }
        public string IdentityOrPassportOrRegistrationNumber { get; set; }
        public string Initials { get; set; }
        public string SurnameOrCompanyName { get; set; }
        public string BusinessEntity { get; set; }
        public bool ValidateSoftyComp { get; set; }
        public bool ValidateFraudster { get; set; }
        public bool ValidateD3BlackList { get; set; }
        public bool ValidateAvsr { get; set; }
        public int[] FraudsterRejectionCodesToIgnore { get; set; }
        public string[] AvsrBanksToIgnore { get; set; }
        public int TimeoutInSeconds { get; set; }
        public string CellNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
