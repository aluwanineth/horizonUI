using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class EntryAgeVM
    {

        [Required]
        public Int16 EntryAgeCD { get; set; }
        [Required]
        public int MinEntryAge { get; set; }
        [Required]
        public int MaxEntryAge { get; set; }
        [Required]
        public Int16 DispSeq { get; set; }
        [Required]
        public DateTime EffDate { get; set; }
        [Required]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }

        public string DisplayMinMax {
            get
            {
                return MinEntryAge + "-" + MaxEntryAge;
            }
        }
    }
}
