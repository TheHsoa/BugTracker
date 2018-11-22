using BugTracker.BL.Operations.Issues.Commands;
using BugTracker.BL.Operations.Issues.Dtos;

namespace BugTracker.BL.Operations.Issues.Services
{
    public interface ICreateIssueOperationService
    {
        long Create(CreateIssueCommand command);
    }
}