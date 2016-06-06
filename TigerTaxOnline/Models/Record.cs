namespace TigerTaxOnline.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Record
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Record()
        {
            AssignedRules = new HashSet<AssignedRule>();
            Categories = new HashSet<Category>();
            Entries = new HashSet<Entry>();
        }

        public int RecordId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Name { get; set; }

        public int TaxYear { get; set; }

        [Column(TypeName = "date")]
        public DateTime LastModified { get; set; }

        public double TotalExpenses { get; set; }

        public double TotalIncome { get; set; }

        public double NetTotal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssignedRule> AssignedRules { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entry> Entries { get; set; }

        public virtual User User { get; set; }
    }
}
