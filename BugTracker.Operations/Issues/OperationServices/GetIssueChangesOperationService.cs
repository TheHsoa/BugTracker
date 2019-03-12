using System.Collections.Generic;
using System.Transactions;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Operations.Audit.Services;
using BugTracker.BL.Operations.Issues.Services;

namespace BugTracker.Operations.Issues.OperationServices
{
    public sealed class GetIssueChangesOperationService : IGetIssueChangesOperationService
    {
        private readonly IGetEntityChangesOperationService _getEntityChangesOperationService;
        private readonly IGetIssueOperationService _getIssueOperationService;

        public GetIssueChangesOperationService(IGetEntityChangesOperationService getEntityChangesOperationService,
            IGetIssueOperationService getIssueOperationService)
        {
            _getEntityChangesOperationService = getEntityChangesOperationService;
            _getIssueOperationService = getIssueOperationService;
        }

        public IReadOnlyCollection<PerformedOperation> GetChanges(EntityReference<Issue> issueReference)
        {
            using (var scope = new TransactionScope())
            {
                var issue = _getIssueOperationService.Get(issueReference);
                var performedOperations = _getEntityChangesOperationService.GetChanges(issue);

                scope.Complete();

                return performedOperations;
            }
        }
    }
}