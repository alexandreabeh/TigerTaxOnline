namespace TigerTaxOnline
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rule()
        {
            AssignedRules = new HashSet<AssignedRule>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RuleId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string FieldToMatch { get; set; }

        [Required]
        [StringLength(50)]
        public string DegreeOfMatch { get; set; }

        [Required]
        [StringLength(1000)]
        public string StringToMatch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssignedRule> AssignedRules { get; set; }

        public virtual User User { get; set; }
    }
}
