using System;
using System.Linq;
using BugTracker.BL.Dal;
using BugTracker.BL.Domain.Model;
using BugTracker.Storage.Dal;
using BugTracker.Storage.Repositories;

namespace BugTracker.Cli
{
    class Program
    {
        private const string ConnectionName = "BugTrackerDB";

        static void Main()
        {
            using (var context = new DatabaseContext(ConnectionName))
            {
                IRepository<Issue> repository = new IssueRepository(context);

                var date = DateTime.Now;
                var issue = new Issue
                {
                    CreatedOn = date,
                    ModifiedOn = date,
                    Title = "TestTitle1",
                    Notes = "TestNotes1"
                };

                repository.Create(issue);

                var issues = repository.Get().ToList();

                foreach (var entity in issues)
                {
                    Console.WriteLine($"{entity.Notes} {entity.ModifiedOn} {entity.CreatedOn}");
                }

                var savedIssue = repository.Get().FirstOrDefault(x => x.Id == 1);

                if (savedIssue != null)
                {
                    Console.WriteLine($"{savedIssue.Notes} {savedIssue.ModifiedOn}");
                    savedIssue.Notes = "UpdatedNotes";
                    repository.Update(savedIssue);
                }

                var updatedIssue = repository.Get().FirstOrDefault(x => x.Id == savedIssue.Id);


                if (updatedIssue != null)
                {
                    Console.WriteLine($"{updatedIssue.Notes} {updatedIssue.ModifiedOn}");
                }

                Console.ReadKey();
            }
        }
    }
}