using BugTracker.BL.Domain.Model;
using BugTracker.BL.Operations.Issues.Dtos;

namespace BugTracker.BL.Extensions
{
    public static class IssueExtensions
    {
        public static IssueDto ToIssueDto(this Issue issue)
        {
            return new IssueDto
            {
                Id = issue.Id,
                Title = issue.Title,
                Notes = issue.Notes,
                CreatedOn = issue.CreatedOn,
                ModifiedOn = issue.ModifiedOn
            };
        }
    }
}
