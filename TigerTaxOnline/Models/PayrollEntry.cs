namespace TigerTaxOnline.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayrollEntry")]
    public partial class PayrollEntry
    {
        public int PayrollEntryId { get; set; }

        public int UserId { get; set; }

        public int EmployeeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfWork { get; set; }

        public TimeSpan? TimeStarted { get; set; }

        public TimeSpan? TimeFinished { get; set; }

        public double HoursWorked { get; set; }

        public double BasePayPerHour { get; set; }

        public double? Bonus { get; set; }

        public double TotalPay { get; set; }

        public bool HasBeenPaid { get; set; }

        public int PayrollCycleId { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual PayrollCycle PayrollCycle { get; set; }

        public virtual User User { get; set; }
    }
}
