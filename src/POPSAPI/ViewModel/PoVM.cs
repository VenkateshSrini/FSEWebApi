using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POPSAPI.ViewModel
{
    public class PoVM
    {
        public List<PoDetailVM> Details { get; set; }
        
        public DateTime PurchaseDate { get; private set; } = DateTime.Today;
        [Required]
        [StringLength(4, ErrorMessage ="Maximum length for supplier no. exceeded")]
        public string SupplierNumber { get; set; }
    }
}
