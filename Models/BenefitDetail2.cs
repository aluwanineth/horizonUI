namespace HorizonPollyC.Models
{
    public class BenefitDetail2
    {
        public int EntityNo { get; set; }
        public String? Name { get; set; }
        public String? Surname { get; set; }
        public String? Relation { get; set; }
        public String? RelationType { get; set; }
        public String? BenefitType { get; set; }
        public Decimal? CoverAmount { get; set; }
        public Decimal? Premium { get; set; }
        public DateTime? DOC { get; set; }
        public String? IDNumber { get; set; } // only sa id will do
        public String? WaitingPeriod { get; set; }
        public DateTime? DOB { get; set; }
        public Decimal? PremiumTotal { get; set; }
    }
}
