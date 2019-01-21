using BugTracker.BL.Operations.Issues.Commands.Abstract;

namespace BugTracker.BL.Operations.Issues.Commands
{
    public sealed class RenameIssueCommand : IUpdateIssueCommand
    {
        public long Id { get; }
        public string Title { get; }

        public RenameIssueCommand(long id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
