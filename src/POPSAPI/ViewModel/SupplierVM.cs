﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POPSAPI.ViewModel
{
    public class SupplierVM
    {
        [StringLength(4,ErrorMessage ="Maximum length exceeded for SUpplier Id")]
        public string ID { get; set; }
        [Required]
        [StringLength(15,ErrorMessage ="Maximum length excedded for supplier name")]
        public string Name { get; set; }
        [StringLength(40,ErrorMessage ="maximum length exceeded for address")]
        public string Address { get; set; }
    }
}
