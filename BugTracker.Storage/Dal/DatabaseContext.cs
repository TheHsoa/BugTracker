using BugTracker.Storage.Model;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Storage.Dal
{
    public sealed class DatabaseContext : DbContext
    {
        public DbSet<PersistenceIssue> Issues { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersistenceIssue>().ToTable("Issue", "Issues");

            base.OnModelCreating(modelBuilder);
        }
    }
}