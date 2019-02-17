using System.Net;

namespace BugTracker.BL.Exceptions
{
    public class CommandValidationException : BaseApplicationException
    {
        public CommandValidationException(string message) : base(message, HttpStatusCode.BadRequest)
        {
        }
    }
}
