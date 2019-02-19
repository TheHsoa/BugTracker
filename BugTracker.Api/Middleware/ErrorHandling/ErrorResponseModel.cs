namespace BugTracker.Api.Middleware.ErrorHandling
{
    public class ErrorResponseModel
    {
        public ErrorResponseModel(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}