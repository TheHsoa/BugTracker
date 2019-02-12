using BugTracker.BL.Exceptions;
using BugTracker.BL.Operations.Issues.Commands;
using BugTracker.BL.Validation.Abstract;
using BugTracker.Resources;

namespace BugTracker.BL.Validation.Issues
{
    public sealed class AddNoteCommandToIssueValidator : ICommandValidator<AddNoteToIssueCommand>
    {
        public void Validate(AddNoteToIssueCommand command)
        {
            var message = string.Empty;

            if (command.Id == 0)
                message.AddErrorMessage(string.Format(EMResources.FieldMustNotBeNullOrEmpty,
                    MetadataResources.IssueId));

            if (string.IsNullOrEmpty(command.Note))
                message.AddErrorMessage(string.Format(EMResources.FieldMustNotBeNullOrEmpty,
                    MetadataResources.IssueNote));

            if(!string.IsNullOrEmpty(message)) throw new CommandValidationException(message);
        }
    }
}
