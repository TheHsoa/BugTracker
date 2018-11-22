using BugTracker.BL.Operations.Issues.Commands;

namespace BugTracker.BL.Operations.Issues.Services
{
    public interface IUpdateIssueOperationService
    {
        void Update(long id, UpdateIssueCommand command);

    }
}