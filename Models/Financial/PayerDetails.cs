namespace HorizonPollyC.Models.Financial
{
    public class PayerDetails
    {
        public int EntityID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string IdNumber { get; set; }
        public string PassportNumber { get; set; }
        public string RelationToMember { get; set; }
        public DateTime DOB { get; set; }
        public byte GenderCD { get; set; }
        public string CellNumber { get; set; }
        public string HomeNumber { get; set; }
        public string WorkNumber { get; set; }
        public string EmailAddress { get; set; }
        public string EmployerName { get; set; }
        public string EmployerNumber { get; set; }
        public string UserID { get; set; }
    }
}
