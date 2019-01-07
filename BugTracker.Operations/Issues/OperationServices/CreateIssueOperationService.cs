
using System;
using BugTracker.BL.Dal;
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
        
        public long Create(CreateIssueCommand command)
        {
                var createdOn = DateTime.Now;
                var createdIssueId = _repository.Create(new Issue
                {
                    Title = command.Title,
                    Notes = command.Notes,
                    CreatedOn = createdOn,
                    ModifiedOn = createdOn
                });

                return createdIssueId;
        }
    }
}