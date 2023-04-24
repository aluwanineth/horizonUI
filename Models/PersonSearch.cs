using System;

namespace HorizonPollyC.Models
{
    public class PersonSearch
    {
        //public int EntityID { get; set; }
        //public string PersonFirstName { get; set; }
        //public string PersonSurname { get; set; }
        //public Nullable<System.DateTime> PersonDOB { get; set; }
        //public string RewardStatus { get; set; }

        public int EntityID { get; set; }
        public int EntityNo { get; set; }
        public string? PersonFirstName { get; set; }
        public string? PersonSurname { get; set; }
        public Nullable<System.DateTime> PersonDOB { get; set; }
        public string? PersonSAIDNo { get; set; }
        public string? PersonPassportNo { get; set; }
        public string? CellphoneNo { get; set; }
        public string? EmailAddress { get; set; }
        public string? LegacyPolicyNo { get; set; }
        public string? RewardStatus { get; set; }
        public string? PlanStatus1 { get; set; }
        public string? DebicheckStatus { get; set; }
        public string? SalesPerson { get; set; }
        public int? Policy_NO { get; set; }
        public string? IFANo { get; set; }
        public string? PlanTypeDescription { get; set; }
        public string? PlanStatus2 { get; set; }
        public System.DateTime? Status_Date { get; set; }
        public System.DateTime? Date_of_Commencement { get; set; }
        public string? OwnerNames { get; set; }
        public string? PayerNames { get; set; }
        public decimal? Premium { get; set; }

    }
}