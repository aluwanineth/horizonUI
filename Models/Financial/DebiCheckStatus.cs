namespace HorizonPollyC.Models.Financial
{
    public class DebiCheckStatus
    {
        public bool Success { get; set; }
        public List<Result> Result { get; set; }
    }

    public class Result
    {
        public bool Success { get; set; }
        public List<Data> Data { get; set; }
        public string Message { get; set; }
    }



    public class Data
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

    // {"Success":true,"Result":[{"Success":true,"data":[{"Amount":199.00,"ApplicationNumber":null,"IFABusinessFeeIncluded":false,"Success":true,"Message":null,"Status":"NotAllowed","PayerIdentityNumber":null,"PayerMobileTelephoneNumber":null,"PolicyNumber":"615114780"}],"Message":"Success"}]}
}