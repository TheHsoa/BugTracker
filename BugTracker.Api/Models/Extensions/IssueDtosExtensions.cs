using BugTracker.Api.Models.Issue;
using BugTracker.BL.Operations.Issues.Commands;

namespace BugTracker.Api.Models.Extensions
{
    public static class IssueDtosExtensions
    {
        public static CreateIssueCommand ToCreateIssueCommand(this CreateIssueDto createIssueDto)
        {
            return new CreateIssueCommand
            {
                Title = createIssueDto.Title,
                Notes = createIssueDto.Notes
            };
        }
        public static UpdateIssueCommand ToUpdateIssueCommand(this UpdateIssueDto updateIssueDto)
        {
            return new UpdateIssueCommand
            {
                Title = updateIssueDto.Title,
                Notes = updateIssueDto.Notes
            };
        }
    }
}
