using System.Collections.Generic;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model;

namespace BugTracker.BL.Operations.Issues.Services
{
    public interface IGetIssueOperationService
    {
        Issue Get(EntityReference<Issue> issueReference);
        IEnumerable<Issue> Get();

    }
}
