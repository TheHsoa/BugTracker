using System.Data.SqlServerCe;

namespace BugTracker.DB.Database
{
    public static class SqlCompactDatabaseGenerator
    {
        public static void GenerateDatabase(string connectionString)
        {
            var en = new SqlCeEngine(connectionString);
            if (!en.Verify())
            {
                en.CreateDatabase();
            }
        }
    }
}
