using System;
using System.Transactions;
using BugTracker.BL.Dal;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Operations.Issues.Commands;
using BugTracker.BL.Operations.Issues.Services;

namespace BugTracker.Operations.Issues.OperationServices
{
    public sealed class UpdateIssueOperationService : IUpdateIssueOperationService
    {
        private readonly IRepository<Issue> _repository;

        public UpdateIssueOperationService(IRepository<Issue> repository)
        {
            _repository = repository;
        }

        public void Update(long id, UpdateIssueCommand command)
        {
            using (var scope = new TransactionScope())
            {
                var issue = _repository.Get(id);

                issue.Notes = command.Notes;
                issue.Title = command.Title;
                issue.ModifiedOn = DateTime.Now;

                _repository.Update(issue);

                scope.Complete();
            }
        }
    }
}