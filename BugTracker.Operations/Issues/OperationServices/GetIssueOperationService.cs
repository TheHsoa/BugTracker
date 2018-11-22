using System.Collections.Generic;
using System.Linq;
using BugTracker.BL.Dal;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Extensions;
using BugTracker.BL.Operations.Issues.Dtos;
using BugTracker.BL.Operations.Issues.Services;

namespace BugTracker.Operations.Issues.OperationServices
{
    public sealed class GetIssueOperationService : IGetIssueOperationService
    {
        private readonly IRepository<Issue> _repository;

        public GetIssueOperationService(IRepository<Issue> repository)
        {
            _repository = repository;
        }

        public IssueDto Get(long id)
        {
            var issue = _repository.Get(id);

            return issue.ToIssueDto();
        }

        public IEnumerable<IssueDto> Get()
        {
            var issues = _repository.Get();

            return issues.Select(x => x.ToIssueDto());
        }
    }
}
