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
        static void Main()
        {
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
                     using (var context = new DatabaseContext())
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
  
                         var issues = repository.Get(1).ToList();
  
                         foreach (var entity in issues)
                         {
                             Console.WriteLine($"{entity.Notes} {entity.ModifiedOn} {entity.CreatedOn}");
                         }
  
                         var savedIssue = repository.Get(1).FirstOrDefault();
  
                         if (savedIssue != null)
                         {
                             Console.WriteLine($"{savedIssue.Notes} {savedIssue.ModifiedOn}");
                             savedIssue.Notes = "UpdatedNotes";
                             repository.Update(savedIssue);
                         }
  
                         var updatedIssue = repository.Get(savedIssue.Id).FirstOrDefault();
  
  
                         if (updatedIssue != null)
                         {
                             Console.WriteLine($"{updatedIssue.Notes} {updatedIssue.ModifiedOn}");
                         }
  
                         Console.ReadKey();
                     }
        }

    }
}