using System;
using System.Net;
using BugTracker.BL.Exceptions;
using BugTracker.Resources;

namespace BugTracker.Api.Middleware.ErrorHandling
{
    public static class ExceptionExtensions
    {
        public static ErrorDescription GetDescription(this Exception exception)
        {
            switch (exception)
            {
                case UnknownCommandException _:
                    return new ErrorDescription(FormatMessage(exception), HttpStatusCode.BadRequest);

                case CommandValidationException _:
                    return new ErrorDescription(FormatMessage(exception), HttpStatusCode.BadRequest);

                case EntityNotFoundException _:
                    return new ErrorDescription(FormatMessage(exception), HttpStatusCode.BadRequest);

                case BusinessLogicException _:
                    return new ErrorDescription(FormatMessage(exception), HttpStatusCode.BadRequest);

                default:
                    return new ErrorDescription(FormatMessage(EMResources.InternalServerError),
                        HttpStatusCode.InternalServerError);
            }
        }

        private static string FormatMessage(string resourceKey)
        {
            return resourceKey;
        }

        private static string FormatMessage(Exception exception)
        {
            return exception.Message;
        }

        public sealed class ErrorDescription
        {
            public ErrorDescription(string message, HttpStatusCode code)
            {
                Message = message;
                Code = code;
            }

            public string Message { get; }
            public HttpStatusCode Code { get; }
        }
    }
}