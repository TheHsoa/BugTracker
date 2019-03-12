using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Operations.Issues.Commands;

namespace BugTracker.BL.Operations.Issues.Services
{
    public interface ICreateIssueOperationService
    {
        EntityReference<Issue> Create(CreateIssueCommand command);
    }
}