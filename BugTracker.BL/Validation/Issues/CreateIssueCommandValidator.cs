using BugTracker.BL.Exceptions;
using BugTracker.BL.Operations.Issues.Commands;
using BugTracker.BL.Validation.Abstract;
using BugTracker.Resources;

namespace BugTracker.BL.Validation.Issues
{
    public sealed class CreateIssueCommandValidator : ICommandValidator<CreateIssueCommand>
    {
        public void Validate(CreateIssueCommand command)
        {
            var message = string.Empty;

            if (string.IsNullOrEmpty(command.Title))
                message = message.AddErrorMessage(string.Format(EMResources.PropertyMustNotBeNullOrEmpty,
                    MetadataResources.IssueTitle));

            if (string.IsNullOrEmpty(command.Notes))
                message = message.AddErrorMessage(string.Format(EMResources.PropertyMustNotBeNullOrEmpty,
                    MetadataResources.IssueNotes));

            if (command.Title != null && command.Title.Length > 128)
                message = message.AddErrorMessage(string.Format(EMResources.PropertyLengthLessThan,
                    MetadataResources.IssueTitle, 128));

            if (command.Notes?.Length > 1024)
                message = message.AddErrorMessage(string.Format(EMResources.PropertyLengthLessThan,
                    MetadataResources.IssueNotes, 1024));

            if (!string.IsNullOrEmpty(message)) throw new CommandValidationException(message);
        }
    }
}
