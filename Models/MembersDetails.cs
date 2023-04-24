using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonPollyC.Models
{
    public class MembersDetails
    {
        public Int32 EntityNo { get; set; }
        public String? Title { get; set; }
        public Int32? TitleID { get; set; }
        public String? FirstName { get; set; }
        public String? Surname { get; set; }
        public String? IDorPassportNo { get; set; }
        public String? LegalNoType { get; set; }
        public DateTime? DateofBirth { get; set; }
        public String? FaxNumber { get; set; }
        public String? HomeNumber { get; set; }
        public Boolean? PreferredHome { get; set; }
        public String? EmailAddress { get; set; }
        public Boolean? PreferredEmail { get; set; }
        public String? CellNumber { get; set; }
        public Boolean? PreferredCell { get; set; }
        public String? PhysicalAddress1 { get; set; }
        public String? PhysicalAddress2 { get; set; }
        public String? PhysicalSuburb { get; set; }
        public String? PhysicalTownCity { get; set; }
        public String? PhysicalPostalCode { get; set; }
        public String? PostalAddress1 { get; set; }
        public String? PostalAddress2 { get; set; }
        public String? PostalSuburb { get; set; }
        public String? PostalTownCity { get; set; }
        public String? PostalPostalCode { get; set; }
        public Int32? GenderID { get; set; }
        public Int32? SmokerCD { get; set; }

    }
}
