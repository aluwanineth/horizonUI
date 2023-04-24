using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Financial
{
    public class FinancialDetailsVM
    {
        public int EntityID { get; set; }
        public string UserID { get; set; }
        public string Title { get; set; }
        public byte TitleCD { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [StringLength(13, MinimumLength = 13)]
        public string IDNumber { get; set; }
        public string PassportNumber { get; set; }
        public string RelationshipToMember { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [Required]
        public string Gender { get; set; }
        public int GenderCD { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string CellNumber { get; set; }
        public string HomeNumber { get; set; }
        public string WorkNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string BankAccHolder { get; set; }
        [Required]
        public string BankName { get; set; }
        public int BankId { get; set; }
        [Required]
        public string BankAccNo { get; set; }
        [Required]
        public string BankAccBranchCode { get; set; }
        [Required]
        public string AccountType { get; set; }
        public int BankAccTypeCD { get; set; }
        [Required]
        public short FirstDebitDay { get; set; } //??//
        [Required]
        public string PaymentMethod { get; set; }
        public int PaymentMethodId { get; set; }
        [Required]
        public int EarlyWEPH { get; set; }
        public IEnumerable<int> PolicyBankDetails { get; set; } = new List<int>();
        public IEnumerable<int> PolicyDebitDays { get; set; } = new List<int>();
    }
}
