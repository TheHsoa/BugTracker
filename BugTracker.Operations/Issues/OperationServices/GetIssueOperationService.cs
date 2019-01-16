using System.Collections.Generic;
using System.Transactions;
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
            using (var scope = new TransactionScope())
            {
                var issue = _repository.Get(id);

                scope.Complete();

                return issue;
            }
        }

        public IEnumerable<Issue> Get()
        {
            using (var scope = new TransactionScope())
            {
                var issues = _repository.Get();

                scope.Complete();

                return issues;
            }
        }
    }
}
