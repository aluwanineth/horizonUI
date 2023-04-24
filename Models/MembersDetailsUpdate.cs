namespace HorizonPollyC.Models
{
    public class MembersDetailsUpdate
    {
        public int EntityNo { get; set; }
        public int? PreferredTelTypeCD { get; set; } 
        public int? TitleCD { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String? FaxNumber { get; set; }
        public String? HomeNumber { get; set; }
        public String? EmailAddress { get; set; }
        public String? CellNumber { get; set; }
        public String? PhysicalAddressLine1 { get; set; }
        public String? PhysicalAddressLine2 { get; set; }
        public String? PhysicalSuburb { get; set; }
        public String? PhysicalTownCity { get; set; }
        public String? PhysicalPostalCode { get; set; }
        public String? PostalAddressLine1 { get; set; }
        public String? PostalAddressLine2 { get; set; }
        public String? PostalSuburb { get; set; }
        public String? PostalTownCity { get; set; }
        public String? PostalPostalCode { get; set; }
        public String? UserID { get; set; }
    }
}
