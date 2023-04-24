namespace HorizonPollyC.Models.Financial
{
    public class RequestMandateResponse
    {
        public bool Success { get; set; }
        public bool DidError { get; set; }
        public RequestMandateResponseResult result { get; set; }

    }

    public class RequestMandateResponseResult
    {
        public bool Success { get; set; }
        public bool DidError { get; set; }
        public string Message { get; set; }
        public RequestMandateData Data { get; set; } = null;
    }
    public class  RequestMandateData
   {
    public decimal Amount { get; set; }
    public string ApplicationNumber { get; set; }
    public bool IFABusinessFeeIncluded { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public string Status { get; set; }
    public string PayerIdentityNumber { get; set; }
    public string PayerMobileTelephoneNumber { get; set; }
    public string PolicyNumber { get; set; }
}
}
