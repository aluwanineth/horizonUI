using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class LoadingVM
    {
        [Required]
        public Int16 LoadingCD { get; set; }
        public Int16 LoadingTypeCD { get; set; }
        [Required]
        public string SDescr { get; set; }
        [Required]

        public decimal LoadingAmt { get; set; }
        [Required]
        public decimal LoadingPerc { get; set; }
        [Required]
        public Int16 DispSeq { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EffDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpDate { get; set; }
        public bool IsActive { get; set; }
    }
}
