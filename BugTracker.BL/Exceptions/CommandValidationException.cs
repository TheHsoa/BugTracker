namespace BugTracker.BL.Exceptions
{
    public class CommandValidationException : BugTrackerApplicationException
    {
        public CommandValidationException(string message) : base(message)
        {
        }
    }
}