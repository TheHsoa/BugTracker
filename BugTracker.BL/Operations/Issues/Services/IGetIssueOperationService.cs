using System.Collections.Generic;
using BugTracker.BL.Domain.Model;

namespace BugTracker.BL.Operations.Issues.Services
{
    public interface IGetIssueOperationService
    {
        Issue Get(long id);
        IEnumerable<Issue> Get();

    }
}
