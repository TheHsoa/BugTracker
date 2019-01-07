namespace BugTracker.BL.Operations.Issues.Commands
{
    public sealed class CreateIssueCommand
    {
        public string Title { get; set; }
        public string Notes { get; set; }
    }
}
