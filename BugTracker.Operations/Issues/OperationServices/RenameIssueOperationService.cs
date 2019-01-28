using System;
using System.Transactions;
using BugTracker.BL.Dal;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Operations.Issues.Commands;
using BugTracker.BL.Operations.Issues.Services;

namespace BugTracker.Operations.Issues.OperationServices
{
    public sealed class RenameIssueOperationService : IRenameIssueOperationService
    {
        private readonly IRepository<Issue> _repository;

        public RenameIssueOperationService(IRepository<Issue> repository)
        {
            _repository = repository;
        }

        public void Rename(RenameIssueCommand command)
        {
            using (var scope = new TransactionScope())
            {

                var issue = _repository.Get(command.Id.ToEntityReference<Issue>());

                issue = new Issue(issue.Id, command.Title, issue.Notes, issue.CreatedOn, modifiedOn: DateTime.Now);

                _repository.Update(issue);

                scope.Complete();
            }
        }
    }
}