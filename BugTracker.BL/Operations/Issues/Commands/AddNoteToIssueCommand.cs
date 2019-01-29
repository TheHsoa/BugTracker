using BugTracker.BL.Operations.Issues.Commands.Abstract;

namespace BugTracker.BL.Operations.Issues.Commands
{
    public sealed class AddNoteToIssueCommand : IUpdateIssueCommand
    {
        public long Id { get; }
        public string Note { get; }

        public AddNoteToIssueCommand(long id, string note)
        {
            Id = id;
            Note = note;
        }
    }
}
