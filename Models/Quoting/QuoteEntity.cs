namespace HorizonPollyC.Models.Quoting
{
    public class QuoteEntity
    {
        ///Beneficiay or Extended member
        public int QuoteNo { get; set; }
        public int PolicyNo { get; set; }
        public string EntityType { get; set; }
        public int EntityID { get; set; }

        public Int16? Relationid { get; set; }
        public string RelationDesc { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public Int16 TitleID { get; set; }
        public string Title { get; set; }
        public string IdNumber { get; set; }
        public string PassportNo { get; set; }
        public string Gender { get; set; }
        public Int16? GenderID { get; set; }
        public int NationalityID { get; set; }
        public string NationalityDesc { get; set; }
        public DateTime DOB { get; set; }
        public string CellNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DOC { get; set; }
        public decimal? Allocation { get; set; }

        public decimal PlanRate { get; set; }
        public int WaitingPeriod { get; set; }

        public decimal CoveredAmount { get; set; }

        public bool isAlsoExtendedMember { get; set; }
        public bool isAlsoBeneficiary { get; set; }

        public Address PostalAddress { get; set; }
        public Address PhysicalAddress { get; set; }

        public List<QuoteBenefits> QuoteBenefits { get; set; }


    }
}
