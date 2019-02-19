namespace BugTracker.Api.Middleware.Logging
{
    public class RequestLog
    {
        public string TraceId { get; set; }
        public string Scheme { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public string Body { get; set; }
    }
}