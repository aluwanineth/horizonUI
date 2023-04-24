namespace HorizonPollyC.Models.Financial
{
    public class UpdateAccountHolderVM
    {
        public Guid Id { get; set; }

        public string IdentityNumber { get; set; }
        public string PassportNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string BusinessName { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneWork { get; set; }
        public string PhoneFax { get; set; }
        public string PhoneCell { get; set; }
        public string EmailAddress { get; set; }
        public string AlternateEmailAddress { get; set; }
    }
}
