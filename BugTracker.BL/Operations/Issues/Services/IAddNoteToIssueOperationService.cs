using BugTracker.BL.Operations.Issues.Commands;

namespace BugTracker.BL.Operations.Issues.Services
{
    public interface IAddNoteToIssueOperationService
    {
        void AddNote(AddNoteToIssueCommand command);
    }
}