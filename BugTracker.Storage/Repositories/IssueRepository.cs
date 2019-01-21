using System.Collections.Generic;
using System.Linq;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model;
using BugTracker.Storage.Dal;
using BugTracker.Storage.Extensions;
using BugTracker.Storage.Model;

namespace BugTracker.Storage.Repositories
{
    public class IssueRepository : Repository<Issue>
    {
        public IssueRepository(DatabaseContext context) : base(context)
        {
        }

        public override void Update(Issue entity)
        {
            var dbIssue = Context.Issues.FirstOrDefault(x => x.Id == entity.Id);

            if (dbIssue == null) throw new KeyNotFoundException();

            dbIssue.Notes = entity.Notes;
            dbIssue.Title = entity.Title;
            dbIssue.ModifiedOn = entity.ModifiedOn;

            Context.Issues.Update(dbIssue);

            Context.SaveChanges();
        }

        public override long Create(Issue entity)
        {
            var newIssue = new PersistenceIssue
            {
                Title = entity.Title,
                Notes = entity.Notes,
                CreatedOn = entity.CreatedOn,
                ModifiedOn = entity.ModifiedOn
            };

            Context.Issues.Add(newIssue);

            Context.SaveChanges();

            return newIssue.Id;
        }

        public override IEnumerable<Issue> Get()
        {
            return Context.Issues.AsEnumerable().Select(x => x.ToIssue());
        }

        public override Issue Get(EntityReference<Issue> issueEntityReference)
        {
            return Context.Issues.Where(x => issueEntityReference.Id == x.Id).AsEnumerable()
                .Select(x => x.ToIssue()).FirstOrDefault();
        }
    }
}