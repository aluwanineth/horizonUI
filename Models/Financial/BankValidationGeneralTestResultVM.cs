namespace HorizonPollyC.Models.Financial
{
    public class BankValidationGeneralTestResultVM
    {
        public bool WasTestPerformed { get; set; }
        public bool IsValid { get; set; }

        public string Message { get; set; }
    }
}
