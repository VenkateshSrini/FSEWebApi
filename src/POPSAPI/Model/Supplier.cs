﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POPSAPI.Model
{
    [Table("SUPPLIER")]
    public class Supplier
    {
        [Required]
        [Column("SUPLNO", TypeName ="CHAR(4)")]
        public string SupplierNumber { get; set; }
        [Column("SUPLNAME", TypeName ="VARCHAR(15)")]
        [Required]
        public string SupplierName { get; set; }
        [Column("SUPLADDR", TypeName ="VARCHAR(40)")]
        public string SupplierAddress { get; set; }
    }
}
