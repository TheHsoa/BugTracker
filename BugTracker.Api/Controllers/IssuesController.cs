using System.Collections.Generic;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Operations.Issues.Commands;
using BugTracker.BL.Operations.Issues.Services;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Api.Controllers
{
    [Route("api/issues")]
    public class IssuesController : Controller
    {
        private readonly ICreateIssueOperationService _createIssueOperationService;
        private readonly IGetIssueOperationService _getIssueOperationService;
        private readonly IUpdateIssueOperationService _updateIssueOperationService;

        public IssuesController(ICreateIssueOperationService createIssueOperationService,
            IUpdateIssueOperationService updateIssueOperationService,
            IGetIssueOperationService getIssueOperationService)
        {
            _createIssueOperationService = createIssueOperationService;
            _updateIssueOperationService = updateIssueOperationService;
            _getIssueOperationService = getIssueOperationService;
        }

        // GET api/issues/5
        [HttpGet("{id}")]
        public ActionResult<Issue> Get(long id)
        {
            return _getIssueOperationService.Get(id);
        }

        // GET api/issues/
        [HttpGet]
        public ActionResult<IEnumerable<Issue>> Get()
        {
            return Ok(_getIssueOperationService.Get());
        }

        // POST api/issues
        [HttpPost]
        public ActionResult<Issue> Create([FromBody] CreateIssueCommand createIssueCommand)
        {
            var createdIssueId = _createIssueOperationService.Create(createIssueCommand);

            return Get(createdIssueId);
        }

        // PATCH api/issues/5
        [HttpPatch("{id}")]
        public IActionResult Update(long id, [FromBody] UpdateIssueCommand updateIssueCommand)
        {
            _updateIssueOperationService.Update(id, updateIssueCommand);

            return NoContent();
        }
    }
}