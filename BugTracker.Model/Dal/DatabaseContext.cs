using System.Data.Entity;
using BugTracker.Dal.Model.Entities;

namespace BugTracker.Dal.Dal
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(string connectionName) : base(nameOrConnectionString: connectionName)
        {
        }
             
        public DbSet<Issue> Issue { get; set; }
    }
}
