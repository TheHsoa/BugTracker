using System.Collections.Generic;
using BugTracker.BL.Operations.Issues.Dtos;

namespace BugTracker.BL.Operations.Issues.Services
{
    public interface IGetIssueOperationService
    {
        IssueDto Get(long id);
        IEnumerable<IssueDto> Get();

    }
}
