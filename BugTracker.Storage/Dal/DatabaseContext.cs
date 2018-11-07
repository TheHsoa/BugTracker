using System.Configuration;
using System.Data.Entity;
using BugTracker.Storage.Database;
using BugTracker.Storage.Model;

namespace BugTracker.Storage.Dal
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(string connectionName) : base(connectionName)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            SqlCompactDatabaseGenerator.GenerateDatabase(connectionString);
        }

        public DbSet<Issue> Issue { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Issue>().HasKey(x => x.Id);
            modelBuilder.Entity<Issue>().Property(x => x.CreatedOn).IsRequired();
            modelBuilder.Entity<Issue>().Property(x => x.ModifiedOn).IsRequired();
            modelBuilder.Entity<Issue>().Property(x => x.Title).IsRequired().HasMaxLength(128);
            modelBuilder.Entity<Issue>().Property(x => x.Notes).IsRequired().HasMaxLength(1024);

            base.OnModelCreating(modelBuilder);
        }
    }
}