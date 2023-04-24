namespace HorizonPollyC.Models.Financial
{
    public class RegisterAccountResultVM
    {
        public Guid Id { get; set; } // This is the AccountId
        public bool IsNew { get; set; }
        public string Message { get; set; }
    }
}
