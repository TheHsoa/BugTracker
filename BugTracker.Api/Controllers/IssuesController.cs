using System.Collections.Generic;
using BugTracker.Api.Models.Extensions;
using BugTracker.Api.Models.Issue;
using BugTracker.BL.Operations.Issues.Dtos;
using BugTracker.BL.Operations.Issues.Services;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Api.Controllers
{
    [Route("api/issues")]
    public class IssuesController : Controller
    {
        private readonly ICreateIssueOperationService _createIssueOperationService;
        private readonly IUpdateIssueOperationService _updateIssueOperationService;
        private readonly IGetIssueOperationService _getIssueOperationService;
        public IssuesController(ICreateIssueOperationService createIssueOperationService, IUpdateIssueOperationService updateIssueOperationService, IGetIssueOperationService getIssueOperationService)
        {
            _createIssueOperationService = createIssueOperationService;
            _updateIssueOperationService = updateIssueOperationService;
            _getIssueOperationService = getIssueOperationService;
        }

        // GET api/issues/5
        [HttpGet("{id}")]
        public ActionResult<IssueDto> Get(long id)
        {
            return _getIssueOperationService.Get(id);
        }

        // GET api/issues/
        [HttpGet]
        public ActionResult<IEnumerable<IssueDto>> Get()
        {
            return Ok(_getIssueOperationService.Get());
        }

        // POST api/issues
        [HttpPost]
        public ActionResult<IssueDto> Create([FromBody] CreateIssueDto createIssueDto)
        {
            var command = createIssueDto.ToCreateIssueCommand();

            var createdIssueId = _createIssueOperationService.Create(command);

            return Get(createdIssueId);
        }

        // PUT api/issues/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] UpdateIssueDto updateIssueDto)
        {
            var command = updateIssueDto.ToUpdateIssueCommand();

            _updateIssueOperationService.Update(id, command);

            return NoContent();
        }
    }
}