using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class DataArtefactVM
    {
        [Required]
        public int DataArtefactCD { get; set; }
        [Required]
        public string DataArtefactCode { get; set; }
        [Required]
        public string DataArtefactDesc { get; set; }
        [Required]
        public string SQLStatement { get; set; }

        public bool IsActive { get; set; }
        [Required]
        public DateTime LastChanged { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
