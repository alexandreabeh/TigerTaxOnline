namespace TigerTaxOnline.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssignedRule
    {
        public int AssignedRuleId { get; set; }

        public int RecordId { get; set; }

        public int RuleId { get; set; }

        public bool IsEnabled { get; set; }

        public virtual Record Record { get; set; }

        public virtual Rule Rule { get; set; }
    }
}
