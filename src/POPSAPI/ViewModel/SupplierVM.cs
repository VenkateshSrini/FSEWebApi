using System.ComponentModel.DataAnnotations;

namespace POPSAPI.ViewModel
{
    public class SupplierVM
    {
        [StringLength(4, ErrorMessage = "Maximum length exceeded for SUpplier Id")]
        public string ID { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Maximum length excedded for supplier name")]
        public string Name { get; set; }
        [StringLength(40, ErrorMessage = "maximum length exceeded for address")]
        public string Address { get; set; }
    }
}
