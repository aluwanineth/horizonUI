namespace HorizonPollyC.Models
{
    public class DiscountDetails
    {
        public decimal? DiscountPer { get; set; }
        public string DiscountReason { get; set; }
        public string IsActive { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
