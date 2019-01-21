using System.Collections.Generic;
using BugTracker.Api.Binders;
using BugTracker.BL.Domain;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Operations.Issues.Commands;
using BugTracker.BL.Operations.Issues.Commands.Abstract;
using BugTracker.BL.Operations.Issues.Services;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Api.Controllers
{
    [Route("api/issues")]
    public class IssuesController : Controller
    {
        private readonly ICreateIssueOperationService _createIssueOperationService;
        private readonly IGetIssueOperationService _getIssueOperationService;
        private readonly IRenameIssueOperationService _renameIssueOperationService;
        private readonly IAddNoteToIssueOperationService _addNoteIssueOperationService;

        public IssuesController(ICreateIssueOperationService createIssueOperationService,
            IRenameIssueOperationService renameIssueIssueOperationService,
            IAddNoteToIssueOperationService addNoteIssueOperationService,
            IGetIssueOperationService getIssueOperationService)
        {
            _createIssueOperationService = createIssueOperationService;
            _renameIssueOperationService = renameIssueIssueOperationService;
            _addNoteIssueOperationService = addNoteIssueOperationService;
            _getIssueOperationService = getIssueOperationService;
        }

        // GET api/issues/5
        [HttpGet("{id}")]
        public ActionResult<Issue> Get(long id)
        {
            return _getIssueOperationService.Get(id.ToEntityReference<Issue>());
        }

        // GET api/issues/
        [HttpGet]
        public ActionResult<IEnumerable<Issue>> Get()
        {
            return Ok(_getIssueOperationService.Get());
        }

        // POST api/issues
        [HttpPost]
        public ActionResult<Issue> Create([ModelBinder(typeof(CreateIssueCommandBinder))] CreateIssueCommand createIssueCommand)
        {
            if (createIssueCommand == null) return BadRequest("Unknown command in body");

            var createdIssueId = _createIssueOperationService.Create(createIssueCommand);
            
            return Get(createdIssueId);
        }

        // PATCH api/issues/5
        [HttpPatch]
        public IActionResult Update([ModelBinder(typeof(UpdateIssueCommandBinder))] IUpdateIssueCommand updateIssueCommand)
        {
            switch (updateIssueCommand)
            {
                case RenameIssueCommand issueCommand:
                    _renameIssueOperationService.Rename(issueCommand);
                    return NoContent();
                case AddNoteToIssueCommand command:
                    _addNoteIssueOperationService.AddNote(command);
                    return NoContent();
                default:
                    return BadRequest("Unknown command in body");
            }
        }
    }
}