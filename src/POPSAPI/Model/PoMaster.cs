using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POPSAPI.Model
{
    public class PoMaster
    {
        [Required]
        [Column("PONO", TypeName = "CHAR(4)")]
        public string PoNumber { get; set; }
        [Column("PODATE", TypeName = "timestamp")]
        public DateTime PoDate { get; set; }

        [Required]
        [Column("SUPLNO", TypeName = "CHAR(4)")]
        public string SUPLNO { get; set; }
        public List<PoDetail> Details { get; set; }

    }
}
