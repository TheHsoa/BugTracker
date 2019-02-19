namespace BugTracker.BL.Exceptions
{
    public class EntityNotFoundException : BugTrackerApplicationException
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}