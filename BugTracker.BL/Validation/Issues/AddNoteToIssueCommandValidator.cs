using BugTracker.BL.Exceptions;
using BugTracker.BL.Operations.Issues.Commands;
using BugTracker.BL.Validation.Abstract;
using BugTracker.Resources;

namespace BugTracker.BL.Validation.Issues
{
    public sealed class AddNoteToIssueCommandValidator : ICommandValidator<AddNoteToIssueCommand>
    {
        public void Validate(AddNoteToIssueCommand command)
        {
            var message = string.Empty;

            if (command.Id == 0)
                message = message.AddErrorMessage(string.Format(EMResources.PropertyMustNotBeNullOrEmpty,
                    MetadataResources.IssueId));

            if (string.IsNullOrEmpty(command.Note))
                message = message.AddErrorMessage(string.Format(EMResources.PropertyMustNotBeNullOrEmpty,
                    MetadataResources.IssueNote));

            if (command.Note?.Length > 1024)
                message = message.AddErrorMessage(string.Format(EMResources.PropertyLengthLessThan,
                    MetadataResources.IssueTitle, 1024));

            if (!string.IsNullOrEmpty(message)) throw new CommandValidationException(message);
        }
    }
}
