using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class ProcessControlLogsVM
    {

        [Required]
        public int ProcessID { get; set; }
        [Required]
        public Int32 ProcessCD { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }
        [Required]
        public DateTime EndDateTime { get; set; }
        [Required]
        public string KeyProgressItem { get; set; }
        [Required]
        public string NameOfUser { get; set; }
    }
}
