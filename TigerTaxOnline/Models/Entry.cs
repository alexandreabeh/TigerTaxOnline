namespace TigerTaxOnline.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Entry
    {
        [Key]
        public int EntryId { get; set; }

        public int RecordId { get; set; }

        public int? CategoryId { get; set; }

        [Column(TypeName = "date")]
        public DateTime TransactionDate { get; set; }

        public double Amount { get; set; }

        [StringLength(1000)]
        public string Location { get; set; }

        [StringLength(1000)]
        public string EntryDescription { get; set; }

        [StringLength(1000)]
        public string Other { get; set; }

        public virtual Category Categories { get; set; }

        public virtual Record Records { get; set; }
    }
}
