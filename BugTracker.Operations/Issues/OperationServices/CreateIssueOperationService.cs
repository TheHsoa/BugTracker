
using System;
using System.Transactions;
using BugTracker.BL.Dal;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Operations.Issues.Commands;
using BugTracker.BL.Operations.Issues.Services;

namespace BugTracker.Operations.Issues.OperationServices
{
    public sealed class CreateIssueOperationService : ICreateIssueOperationService
    {
        private readonly IRepository<Issue> _repository;

        public CreateIssueOperationService(IRepository<Issue> repository)
        {
            _repository = repository;
        }

        public EntityReference<Issue> Create(CreateIssueCommand command)
        {
            using (var scope = new TransactionScope())
            {
                var createdOn = DateTime.Now;

                var createdIssueReference =
                    _repository.Add(new Issue(command.Title, command.Notes, createdOn, modifiedOn: createdOn));

                scope.Complete();

                return createdIssueReference;
            }
        }
    }
}