namespace BugTracker.Api.Middleware.Logging
{
    public class ResponseLog
    {
        public string TraceId { get; set; }
        public int StatusCode { get; set; }
        public string Body { get; set; }
        public long ElapsedMilliseconds { get; set; }
    }
}
