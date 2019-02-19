namespace BugTracker.BL.Exceptions
{
    public class BusinessLogicException : BugTrackerApplicationException
    {
        public BusinessLogicException(string message) : base(message)
        {
        }
    }
}