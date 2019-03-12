using System;
using System.Transactions;
using BugTracker.BL.Dal;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Exceptions;
using BugTracker.BL.Identities.Operations.Issue;
using BugTracker.BL.Operations.Issues.Commands;
using BugTracker.BL.Operations.Issues.Services;
using BugTracker.Resources;

namespace BugTracker.Operations.Issues.OperationServices
{
    public sealed class RenameIssueOperationService : IRenameIssueOperationService
    {
        private readonly IRepository<Issue> _repository;
        private readonly IAuditService _auditService;


        public RenameIssueOperationService(IRepository<Issue> repository, IAuditService auditService)
        {
            _repository = repository;
            _auditService = auditService;
        }

        public void Rename(RenameIssueCommand command)
        {
            using (var scope = new TransactionScope())
            {

                var issue = _repository.Get(command.Id.ToEntityReference<Issue>());

                if (issue == null)
                    throw new EntityNotFoundException(string.Format(EMResources.EntityNotFound, typeof(Issue).Name,
                        command.Id));

                var operationTime = DateTime.Now;
                var updatedIssue = new Issue(issue.Id, command.Title, issue.Notes, issue.CreatedOn,
                    modifiedOn: operationTime);

                _repository.Update(issue);
                _auditService.LogOperation<Issue, RenameIssueIdentity>(issue, updatedIssue, operationTime);

                scope.Complete();
            }
        }
    }
}