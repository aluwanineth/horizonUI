using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class TableVM
    {
        [Required]
        public Int16 TableCD { get; set; }
        [Required]

        public string TableName { get; set; }
        [Required]

        public Int16 DispSeq { get; set; }
        [Required]

        public string SDesc { get; set; }
        [Required]

        public string LDesc { get; set; }

    }
}
