namespace HorizonPollyC.Models
{
    public class Title
    {
        public int TitleCD { get; set; }
        public string SDesc { get; set; }
        public int? DispSeq { get; set; }
        public Nullable<DateTime> EffDate { get; set; }
        public Nullable<DateTime> ExpDate { get; set; }
    }
}
