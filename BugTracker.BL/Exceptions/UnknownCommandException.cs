using BugTracker.Resources;

namespace BugTracker.BL.Exceptions
{
    public class UnknownCommandException : CommandValidationException
    {
        public UnknownCommandException() : base(EMResources.UnknownCommand)
        {
        }
    }
}