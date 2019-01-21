using BugTracker.BL.Operations.Issues.Commands;

namespace BugTracker.BL.Operations.Issues.Services
{
    public interface IRenameIssueOperationService
    {
        void Rename(RenameIssueCommand command);
    }
}