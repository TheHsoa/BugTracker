using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.BL.Operations.Issues.Commands
{
    public sealed class UpdateIssueCommand
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
    }
}
