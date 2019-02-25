using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BugTracker.Api.Middleware.ErrorHandling
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;

            var exceptionDescription = exception.GetDescription();

            response.ContentType = "application/json";
            response.StatusCode = (int) exceptionDescription.Code;
            await response.WriteAsync(
                JsonConvert.SerializeObject(new ErrorResponseModel(exceptionDescription.Message)));
        }
    }
}