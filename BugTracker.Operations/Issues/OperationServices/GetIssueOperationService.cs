using System.Collections.Generic;
using System.Transactions;
using BugTracker.BL.Dal;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Exceptions;
using BugTracker.BL.Operations.Issues.Services;
using BugTracker.Resources;

namespace BugTracker.Operations.Issues.OperationServices
{
    public sealed class GetIssueOperationService : IGetIssueOperationService
    {
        private readonly IRepository<Issue> _repository;

        public GetIssueOperationService(IRepository<Issue> repository)
        {
            _repository = repository;
        }

        public Issue Get(EntityReference<Issue> issueReference)
        {
            using (var scope = new TransactionScope())
            {
                var issue = _repository.Get(issueReference);

                if (issue == null) throw new EntityNotFoundException(string.Format(EMResources.EntityNotFound, typeof(Issue).Name, issueReference.Id));

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
