using System;

namespace BugTracker.BL.Operations.Issues.Dtos
{
    public sealed class IssueDto
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
