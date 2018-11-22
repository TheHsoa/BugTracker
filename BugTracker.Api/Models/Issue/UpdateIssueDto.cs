using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.Models.Issue
{
    public sealed class UpdateIssueDto
    {
        public string Title { get; set; }
        public string Notes { get; set; }
    }
}