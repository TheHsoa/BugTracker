namespace BugTracker.BL.Operations.Issues.Commands
{
    public sealed class CreateIssueCommand
    {
        public string Title { get; }
        public string Notes { get; }

        public CreateIssueCommand(string title, string notes)
        {
            Title = title;
            Notes = notes;
        }
    }
}
