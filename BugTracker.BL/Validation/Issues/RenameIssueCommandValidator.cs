using BugTracker.BL.Exceptions;
using BugTracker.BL.Operations.Issues.Commands;
using BugTracker.BL.Validation.Abstract;
using BugTracker.Resources;

namespace BugTracker.BL.Validation.Issues
{
    public sealed class RenameIssueCommandValidator : ICommandValidator<RenameIssueCommand>
    {
        public void Validate(RenameIssueCommand command)
        {
            var message = string.Empty;

            if (command.Id == 0)
                message = message.AddErrorMessage(string.Format(EMResources.PropertyMustNotBeNullOrEmpty,
                    MetadataResources.IssueId));

            if (string.IsNullOrEmpty(command.Title))
                message = message.AddErrorMessage(string.Format(EMResources.PropertyMustNotBeNullOrEmpty,
                    MetadataResources.IssueTitle));

            if (command.Title?.Length > 128)
                message = message.AddErrorMessage(string.Format(EMResources.PropertyLengthLessThan,
                    MetadataResources.IssueTitle, 128));

            if(!string.IsNullOrEmpty(message)) throw new CommandValidationException(message);
        }
    }
}
