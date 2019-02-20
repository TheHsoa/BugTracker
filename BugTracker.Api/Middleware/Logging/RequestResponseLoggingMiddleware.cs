using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;

namespace BugTracker.Api.Middleware.Logging
{
    public sealed class RequestResponseLoggingMiddleware
    {
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            httpContext.Request.EnableRewind();
            var requestBodyOriginalStream = httpContext.Request.Body;
            var requestLog = await FormatRequest(httpContext.Request, httpContext.TraceIdentifier);
            _logger.LogInformation("Request: {@request}", requestLog);

            var originalBody = httpContext.Response.Body;

            var sw = Stopwatch.StartNew();
            var memStream = new MemoryStream();

            httpContext.Response.Body = memStream;
            try
            {
                await _next(httpContext);
            }
            finally
            {
                memStream.Position = 0;
                await memStream.CopyToAsync(originalBody);
                sw.Stop();

                var responseLog = FormatResponse(httpContext.Response, httpContext.TraceIdentifier,
                    sw.ElapsedMilliseconds);

                if (responseLog.IsCompletedSuccessfully)
                    _logger.LogInformation("Response: {@result}", responseLog);
                else
                    _logger.LogError("Response logging fault: {@result}", responseLog);

                httpContext.Request.Body = requestBodyOriginalStream;
                httpContext.Response.Body = originalBody;
            }
        }


        private static async Task<RequestLog> FormatRequest(HttpRequest request, string traceId)
        {
            var requestBodyStream = new MemoryStream();

            await request.Body.CopyToAsync(requestBodyStream);

            requestBodyStream.Seek(0, SeekOrigin.Begin);

            var requestBodyText = await new StreamReader(requestBodyStream).ReadToEndAsync();

            requestBodyStream.Seek(0, SeekOrigin.Begin);
            request.Body = requestBodyStream;

            return new RequestLog
            {
                TraceId = traceId,
                Scheme = request.Scheme,
                Host = request.Host.Value,
                Path = request.Path,
                QueryString = request.QueryString.Value,
                Body = requestBodyText
            };
        }

        private static async Task<ResponseLog> FormatResponse(HttpResponse response, string traceId,
            long elapsedMilliseconds)
        {
            response.Body.Seek(0, SeekOrigin.Begin);

            var responseBodyText = await new StreamReader(response.Body).ReadToEndAsync();

            response.Body.Seek(0, SeekOrigin.Begin);

            return new ResponseLog
            {
                TraceId = traceId,
                StatusCode = response.StatusCode,
                Body = responseBodyText,
                ElapsedMilliseconds = elapsedMilliseconds
            };
        }
    }
}