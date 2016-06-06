namespace TigerTaxOnline.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            PayrollEntries = new HashSet<PayrollEntry>();
        }

        public int EmployeeId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Display(Name ="Is Active")]
        public bool IsActive { get; set; }

        [Display(Name ="Phone Number")]
        public int? PhoneNumber { get; set; }

        [StringLength(1000)]
        [Display(Name ="Notes")]
        public string Notes { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PayrollEntry> PayrollEntries { get; set; }
    }
}
