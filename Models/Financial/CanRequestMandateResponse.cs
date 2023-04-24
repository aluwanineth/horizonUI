namespace HorizonPollyC.Models.Financial
{
    public class CanRequestMandateResponse
    {
        public bool Success { get; set; }
        public bool DidError { get; set; }

        public CanRequestResult Result  { get; set; }
}

    public class CanRequestResult
    {
        public bool Success { get; set; }
        public bool DidError { get; set; }
        public string Message { get; set; }
        public CanRequestData Data { get; set; }
    }

    public class CanRequestData
    {
        public string MandateType { get; set; }
    }
}
