using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POPSAPI.Model
{
    public class Item
    {
        [Required]
        [Column("ITCODE", TypeName ="CHAR(4)")]
        public string ItemCode { get; set; }
        [Required]
        [Column("ITDESC", TypeName ="VARCHAR(15)")]
        public string ItemDescription { get; set; }
        [Column("ITRATE", TypeName ="Money")]
        public double ItemRate { get; set; }
    }
}
