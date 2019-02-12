using System;
using System.Transactions;
using BugTracker.BL.Dal;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Exceptions;
using BugTracker.BL.Operations.Issues.Commands;
using BugTracker.BL.Operations.Issues.Services;
using BugTracker.Resources;

namespace BugTracker.Operations.Issues.OperationServices
{
    public sealed class AddNoteToIssueOperationService : IAddNoteToIssueOperationService
    {
        private readonly IRepository<Issue> _repository;

        public AddNoteToIssueOperationService(IRepository<Issue> repository)
        {
            _repository = repository;
        }

        public void AddNote(AddNoteToIssueCommand command)
        {
            using (var scope = new TransactionScope())
            {

                var issue = _repository.Get(command.Id.ToEntityReference<Issue>());

                if (issue == null) throw new EntityNotFoundException(string.Format(EMResources.EntityNotFound, typeof(Issue).Name, command.Id));

                issue = new Issue(issue.Id, issue.Title, $"{issue.Notes}{Environment.NewLine}{command.Note}", issue.CreatedOn, modifiedOn: DateTime.Now);

                _repository.Update(issue);

                scope.Complete();
            }
        }
    }
}