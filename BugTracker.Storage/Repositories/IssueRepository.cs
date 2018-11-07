using System;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using BugTracker.BL.Domain.Model;
using BugTracker.Storage.Dal;

namespace BugTracker.Storage.Repositories
{
    public class IssueRepository : Repository<Issue>
    {
        public override void Update(Issue entity)
        {
            var dbIssue = Context.Issue.FirstOrDefault(x => x.Id == entity.Id);

            if(dbIssue == null)  throw new ObjectNotFoundException();

            dbIssue.Notes = entity.Notes;
            dbIssue.Title = entity.Title;
            dbIssue.ModifiedOn = DateTime.UtcNow;

            Context.Entry(dbIssue).State = EntityState.Modified;
            Context.SaveChanges();
        }
        
        public override void Create(Issue entity)
        {
            var newIssue = new Model.Issue
            {
                Title = entity.Title,
                Notes = entity.Notes,
                CreatedOn = entity.CreatedOn,
                ModifiedOn = entity.ModifiedOn
            };

            Context.Issue.Add(newIssue);
            Context.SaveChanges();
        }

        public override IQueryable<Issue> Get()
        {
            return Context.Issue.Select(x => new Issue
            {
                Id = x.Id,
                Notes = x.Notes,
                Title = x.Title,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn
            });
        }

        public override void Delete(Issue entity)
        {
            throw new NotImplementedException();
        }

        public IssueRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
