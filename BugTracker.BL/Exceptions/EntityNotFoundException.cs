using System.Net;

namespace BugTracker.BL.Exceptions
{
    public class EntityNotFoundException : BaseApplicationException
    {
        public EntityNotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {
        }
    }
}
