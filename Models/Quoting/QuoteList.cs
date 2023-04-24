namespace HorizonPollyC.Models.Quoting
{
    public class QuoteListModel
    {
        public int QuoteNo { get; set; }
        public string Partner { get; set; }
        public string Scheme { get; set; }
        public DateTime? EffDate { get; set; }
        public DateTime? ExpDate { get; set; }
        public decimal? Premium { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
