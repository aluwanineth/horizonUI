namespace HorizonPollyC.Models
{
    public class BeneficiaryDetails
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Relation { get; set; }
        public string IDNumber { get; set; }
        public decimal? CoveredAmount { get; set; }
        public decimal? Allocation { get; set; }
        public string DateCeded { get; set; }
        public DateTime? DOB { get; set; }
        public string Status { get; set; }
        public bool Active { get; set; }
    }
}
