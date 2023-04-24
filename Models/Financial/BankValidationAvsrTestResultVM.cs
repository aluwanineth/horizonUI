namespace HorizonPollyC.Models.Financial
{
    public class BankValidationAvsrTestResultVM
    {
        public bool WasTestPerformed { get; set; }
        public bool IsValid { get; set; }

        public string Message { get; set; }

        public Guid QLinkAvsrCheckId { get; set; }

        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public string SessionId { get; set; }

        public int? AccountStatusId { get; set; }

        public bool WasCachedResultUsed { get; set; }
        public bool WasBankAccountFound { get; set; }
        public bool IsBankAccountOpen { get; set; }
        public bool DoesBankAccountTypeMatch { get; set; }
        public bool DoesInitialsMatch { get; set; }
        public bool DoesIdentityNumberMatch { get; set; }
        public bool DoesNameMatch { get; set; }
        public bool DoesAcceptsDebits { get; set; }
        public bool DoesAcceptsCredits { get; set; }
        public bool DidTimeout { get; set; }
        public bool AccountLengthMatch { get; set; }
        public bool MissingParameter { get; set; }
        public bool HasBankAccountBeenOpenForMoreThan3Months { get; set; }

        public DateTime ResponseDate { get; set; }
    }
}
