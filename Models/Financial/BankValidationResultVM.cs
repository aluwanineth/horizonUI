namespace HorizonPollyC.Models.Financial
{
    public class BankValidationResultVM
    {
        public bool IsValid { get; set; }

        public string Message { get; set; }

        public int FraudsterFailure { get; set; }

        public BankValidationGeneralTestResultVM SoftyCompResult { get; set; }
        public BankValidationFraudsterTestResultVM FraudsterResult { get; set; }
        public BankValidationGeneralTestResultVM D3BlackListResult { get; set; }
        public BankValidationAvsrTestResultVM AvsrResult { get; set; }
    }
}
