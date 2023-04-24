namespace HorizonPollyC.Models.Financial
{
    public class BankLookups
    {
        public List<BankGetResult> Banks { get; set; }
        public List<BankAccTypeGetResult> BankAccTypes { get; set; }
    }
    public partial class BankAccTypeGetResult
    {
        public int BankAccTypeCD { get; set; }
        public string CountryCode { get; set; }
        public string BankAccTypeCode { get; set; }
        public string BankAccTypeDesc { get; set; }
        public string BankAccTypeRegEx { get; set; }
        public short? DispSeq { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastChanged { get; set; }
        public string UserID { get; set; }
    }
    public partial class BankGetResult
    {
        public int BankID { get; set; }
        public string BankName { get; set; }
        public int? UniversalBranchCode { get; set; }
    }
}
