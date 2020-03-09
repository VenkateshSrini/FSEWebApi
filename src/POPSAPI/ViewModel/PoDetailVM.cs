using System.ComponentModel.DataAnnotations;

namespace POPSAPI.ViewModel
{
    public class PoDetailVM
    {
        [Required]
        [StringLength(4, ErrorMessage = "Error in Item code")]
        public string ItemNumber { get; set; }

        public int Quantity { get; set; } = 0;
    }
}
