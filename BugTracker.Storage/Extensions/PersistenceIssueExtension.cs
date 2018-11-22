using BugTracker.BL.Domain.Model;
using BugTracker.Storage.Model;

namespace BugTracker.Storage.Extensions
{
    public static class PersistenceIssueExtension
    {
        public static Issue ToIssue(this PersistenceIssue issue)
        {
            return new Issue(issue.Id, issue.Title, issue.Notes, issue.CreatedOn, issue.ModifiedOn);
        }
    }
}
