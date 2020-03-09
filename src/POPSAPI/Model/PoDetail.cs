using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POPSAPI.Model
{
    public class PoDetail
    {
        [Required]
        [Column("PONO", TypeName = "Char(4)")]
        public string PuchaseOrderNumber { get; set; }
        [Required]
        [Column("ITCODE", TypeName = "CHAR(4)")]
        public string ItemNumber { get; set; }
        [Column("QTY", TypeName = "integer")]
        public int Quantity { get; set; }
        public PoMaster PurchaseOrderMaster { get; set; }
    }
}
