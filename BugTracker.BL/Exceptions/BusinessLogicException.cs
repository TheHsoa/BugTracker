using System.Net;

namespace BugTracker.BL.Exceptions
{
    public class BusinessLogicException : BaseApplicationException
    {
        public BusinessLogicException(string message) : base(message, HttpStatusCode.BadRequest)
        {
        }
    }
}
