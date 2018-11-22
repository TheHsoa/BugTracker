using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.Models.Issue
{
    public sealed class CreateIssueDto
    {
        public string Title { get; set; }
        public string Notes { get; set; }
    }
}