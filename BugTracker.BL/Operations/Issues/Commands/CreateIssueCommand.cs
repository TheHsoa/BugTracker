using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.BL.Operations.Issues.Commands
{
    public sealed class CreateIssueCommand
    {
        public string Title { get; set; }
        public string Notes { get; set; }
    }
}
