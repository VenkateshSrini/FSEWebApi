using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POPSAPI.ViewModel
{
    public class ItemVM
    {
        [Required]
        [StringLength(15,ErrorMessage = "Maximum length for Item description exceeded")]
        public string Description { get; set; }
        [Required]
        public double Rate { get; set; }
    }
}
