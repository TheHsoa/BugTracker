using System.Collections.Generic;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Exceptions;
using BugTracker.BL.Operations.Issues.Commands;
using BugTracker.BL.Operations.Issues.Commands.Abstract;
using BugTracker.BL.Operations.Issues.Services;
using BugTracker.BL.Validation.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Api.Controllers
{
    [Route("api/issues")]
    public class IssuesController : Controller
    {
        private readonly IAddNoteToIssueOperationService _addNoteIssueOperationService;

        private readonly ICommandValidator<AddNoteToIssueCommand> _addNoteToIssueCommandValidator;
        private readonly ICommandValidator<CreateIssueCommand> _createIssueCommandValidator;
        private readonly ICreateIssueOperationService _createIssueOperationService;
        private readonly IGetIssueOperationService _getIssueOperationService;
        private readonly ICommandValidator<RenameIssueCommand> _renameIssueCommandValidator;
        private readonly IRenameIssueOperationService _renameIssueOperationService;

        public IssuesController(ICreateIssueOperationService createIssueOperationService,
            IRenameIssueOperationService renameIssueIssueOperationService,
            IAddNoteToIssueOperationService addNoteIssueOperationService,
            IGetIssueOperationService getIssueOperationService,
            ICommandValidator<AddNoteToIssueCommand> addNoteToIssueCommandValidator,
            ICommandValidator<CreateIssueCommand> createIssueCommandValidator,
            ICommandValidator<RenameIssueCommand> renameIssueCommandValidator)
        {
            _createIssueOperationService = createIssueOperationService;
            _renameIssueOperationService = renameIssueIssueOperationService;
            _addNoteIssueOperationService = addNoteIssueOperationService;
            _getIssueOperationService = getIssueOperationService;
            _addNoteToIssueCommandValidator = addNoteToIssueCommandValidator;
            _createIssueCommandValidator = createIssueCommandValidator;
            _renameIssueCommandValidator = renameIssueCommandValidator;
        }

        // GET api/issues/5
        [HttpGet("{id}")]
        public ActionResult<Issue> Get(long id)
        {
            return _getIssueOperationService.Get(id.ToEntityReference<Issue>());
        }

        // GET api/issues
        [HttpGet]
        public ActionResult<IEnumerable<Issue>> Get()
        {
            return Ok(_getIssueOperationService.Get());
        }

        // POST api/issues
        [HttpPost]
        public ActionResult<Issue> Create(CreateIssueCommand createIssueCommand)
        {
            _createIssueCommandValidator.Validate(createIssueCommand);
            var createdIssueId = _createIssueOperationService.Create(createIssueCommand);

            return Get(createdIssueId);
        }

        // PATCH api/issues
        [HttpPatch]
        public IActionResult Update(IUpdateIssueCommand updateIssueCommand)
        {
            switch (updateIssueCommand)
            {
                case RenameIssueCommand command:
                    _renameIssueCommandValidator.Validate(command);
                    _renameIssueOperationService.Rename(command);
                    return NoContent();
                case AddNoteToIssueCommand command:
                    _addNoteToIssueCommandValidator.Validate(command);
                    _addNoteIssueOperationService.AddNote(command);
                    return NoContent();
                default:
                    throw new UnknownCommandException();
            }
        }
    }
}