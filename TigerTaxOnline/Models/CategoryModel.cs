namespace TigerTaxOnline
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Categories1 = new HashSet<Category>();
            Entries = new HashSet<Entry>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryId { get; set; }

        public int RecordId { get; set; }

        public int? ParentCategoryId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Name { get; set; }

        public double Total { get; set; }

        public bool IsExpense { get; set; }

        [StringLength(1000)]
        public string CategoryDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories1 { get; set; }

        public virtual Category Category1 { get; set; }

        public virtual Record Record { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entry> Entries { get; set; }
    }
}
