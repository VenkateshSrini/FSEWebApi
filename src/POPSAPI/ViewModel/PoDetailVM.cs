using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POPSAPI.ViewModel
{
    public class PoDetailVM
    {
        [Required]
        [StringLength(4, ErrorMessage ="Error in Item code")]
        public string ItemNumber { get; set; }

        public int Quantity { get; set; } = 0;
    }
}
