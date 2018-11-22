using BugTracker.Storage.Model;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Storage.Dal
{
    public class DatabaseContext : DbContext
    {
        public DbSet<PersistenceIssue> Issues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./BugTracker.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersistenceIssue>().ToTable("Issue", "Issues");

            base.OnModelCreating(modelBuilder);
        }
    }
}