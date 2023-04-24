using System.ComponentModel.DataAnnotations;

namespace HorizonPollyC.Models.Configuration
{
    public class BordereauxSourceVM
    {
        [Required]
        public Int16 BordereauxSourceCD { get; set; }
        [Required]
        public string SDesc { get; set; }
    }
}
