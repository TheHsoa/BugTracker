using System;
using System.Configuration;
using System.Linq;
using BugTracker.Dal.Dal;
using BugTracker.Dal.Model.Entities;
using BugTracker.DB.Database;

namespace BugTracker.Cli
{
    class Program
    {
        private const string ConnectionName = "BugTrackerDB";
        static void Main()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString;

            SqlCompactDatabaseGenerator.GenerateDatabase(connectionString);

            using (var context = new DatabaseContext(ConnectionName))
            {
                var date = DateTime.Now;
                var issue = new Issue
                {
                    CreatedOn = date,
                    ModifiedOn = date,
                    Title = "TestTitle",
                    Notes = "TestNotes"
                };

                context.Issue.Add(issue);
                context.SaveChanges();
                var issues = context.Issue.ToList();
                var savedIssue = context.Issue.FirstOrDefault(x => x.Id == 1);

                if (savedIssue != null) Console.Write(savedIssue.Notes);
            }

            Console.ReadKey();
        }
    }
}
