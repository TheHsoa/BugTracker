using BugTracker.Storage.Model;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Storage.Dal
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<PersistenceIssue> Issues { get; set; }
        public DbSet<PersistencePerformedOperation> PerformedOperations { get; set; }
        public DbSet<PersistenceEntityChange> EntityChanges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersistenceIssue>().ToTable("Issue", "Issues");
            modelBuilder.Entity<PersistenceEntityChange>().ToTable("EntityChange", "Audit");
            modelBuilder.Entity<PersistencePerformedOperation>().ToTable("PerformedOperation", "Audit")
                .HasMany(x => x.EntityChanges).WithOne().HasForeignKey(x => x.PerformedOperationId);

            base.OnModelCreating(modelBuilder);
        }
    }
}