﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POPSAPI.ViewModel
{
    public class PoVM
    {
        public List<PoDetailVM> Details { get; set; }

        public DateTime PurchaseDate { get; private set; } = DateTime.Today;
        [Required]
        [StringLength(4, ErrorMessage = "Maximum length for supplier no. exceeded")]
        public string SupplierNumber { get; set; }
        [StringLength(4, ErrorMessage = "PO number maximum length exceeded")]
        public string ID { get; set; }
    }
}
