namespace TigerTaxOnline
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TigerTaxOnlineModel : DbContext
    {
        public TigerTaxOnlineModel()
            : base("name=TigerTaxOnlineModel")
        {
        }

        public virtual DbSet<AssignedRule> AssignedRules { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<Rule> Rules { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Categories1)
                .WithOptional(e => e.Category1)
                .HasForeignKey(e => e.ParentCategoryId);

            modelBuilder.Entity<Record>()
                .HasMany(e => e.AssignedRules)
                .WithRequired(e => e.Record)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Record>()
                .HasMany(e => e.Categories)
                .WithRequired(e => e.Record)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Record>()
                .HasMany(e => e.Entries)
                .WithRequired(e => e.Record)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rule>()
                .HasMany(e => e.AssignedRules)
                .WithRequired(e => e.Rule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Records)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Rules)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
