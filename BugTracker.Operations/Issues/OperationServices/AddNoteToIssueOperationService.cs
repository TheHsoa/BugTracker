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
    public sealed class AddNoteToIssueOperationService : IAddNoteToIssueOperationService
    {
        private readonly IRepository<Issue> _repository;
        private readonly IAuditService _auditService;

        public AddNoteToIssueOperationService(IRepository<Issue> repository, IAuditService auditService)
        {
            _repository = repository;
            _auditService = auditService;
        }

        public void AddNote(AddNoteToIssueCommand command)
        {
            using (var scope = new TransactionScope())
            {

                var issue = _repository.Get(command.Id.ToEntityReference<Issue>());

                if (issue == null)
                    throw new EntityNotFoundException(string.Format(EMResources.EntityNotFound, typeof(Issue).Name,
                        command.Id));

                var updatedNotes = $"{issue.Notes}{Environment.NewLine}{command.Note}";

                if (updatedNotes.Length > 1024)
                    throw new BusinessLogicException(string.Format(EMResources.EntityPropertyLengthLessThan,
                        typeof(Issue).Name, MetadataResources.IssueNotes, 1024));

                var operationTime = DateTime.Now;

                var updatedIssue = new Issue(issue.Id, issue.Title, updatedNotes, issue.CreatedOn,
                    modifiedOn: DateTime.Now);

                _repository.Update(updatedIssue);
                _auditService.LogOperation<Issue, AddNoteToIssueIdentity>(issue, updatedIssue, operationTime);

                scope.Complete();
            }
        }
    }
}