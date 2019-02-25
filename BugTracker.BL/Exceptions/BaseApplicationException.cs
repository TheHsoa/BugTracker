using System;

namespace BugTracker.BL.Exceptions
{
    public abstract class BugTrackerApplicationException : ApplicationException
    {
        protected BugTrackerApplicationException(string message) : base(message)
        {
        }
    }
}