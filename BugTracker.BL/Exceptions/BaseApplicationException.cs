using System;
using System.Net;

namespace BugTracker.BL.Exceptions
{
    public abstract class BaseApplicationException : Exception
    {
        public HttpStatusCode Code { get; }

        protected BaseApplicationException(string message, HttpStatusCode code) : base(message)
        {
            Code = code;
        }
    }
}
