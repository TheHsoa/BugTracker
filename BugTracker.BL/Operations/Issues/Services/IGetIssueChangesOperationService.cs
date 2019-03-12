using System.Collections.Generic;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model;

namespace BugTracker.BL.Operations.Issues.Services
{
    public interface IGetIssueChangesOperationService
    {
        IReadOnlyCollection<PerformedOperation> GetChanges(EntityReference<Issue> issueReference);
    }
}