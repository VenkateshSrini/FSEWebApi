using System.ComponentModel.DataAnnotations;

namespace POPSAPI.ViewModel
{
    public class ItemVM
    {
        [StringLength(4, ErrorMessage = "Max length for Item Id exceeded")]
        public string ID { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Maximum length for Item description exceeded")]
        public string Description { get; set; }
        [Required]
        public double Rate { get; set; }
    }
}
