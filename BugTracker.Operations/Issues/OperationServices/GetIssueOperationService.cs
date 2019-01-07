using System.Collections.Generic;
using BugTracker.BL.Dal;
using BugTracker.BL.Domain.Model;
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

        public Issue Get(long id)
        {
            var issue = _repository.Get(id);

            return issue;
        }

        public IEnumerable<Issue> Get()
        {
            var issues = _repository.Get();

            return issues;
        }
    }
}
