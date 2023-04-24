using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonPollyC.Models.Configuration
{
    public class TranslateVM
    {
        [Required]
        public int TranslateID { get; set; }
        [Required]
        public Int16 TableCD { get; set; }
        [Required]
        public int TableEntryID { get; set; }
        [Required]
        public Int16 LanguageCD { get; set; }
        [Required]
        public string TranslationText { get; set; }
        [Required]
        public string TranslationBigText { get; set; }
        [Required]
        public Int16? DispSeq { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EffDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpDate { get; set; }

        public bool IsActive { get; set; }
    }
}
