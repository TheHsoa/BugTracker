using BugTracker.BL.Operations.Issues.Commands;

namespace BugTracker.BL.Operations.Issues.Services
{
    public interface ICreateIssueOperationService
    {
        long Create(CreateIssueCommand command);
    }
}