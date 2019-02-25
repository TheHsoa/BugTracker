using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace BugTracker.Api.Infrastructure.Logging
{
    public static class ConfigureLogging
    {
        public static IWebHostBuilder ConfigureAndAddSerilog(this IWebHostBuilder builder)
        {
            return builder.UseSerilog((context, configuration) =>
                {
                    configuration
                        .MinimumLevel.Information()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                        .WriteTo.RollingFile(new CompactJsonFormatter(), "./logs/log-{Date}.json",
                            fileSizeLimitBytes: null);

#if DEBUG
                    const string outputTemplate =
                        "{Timestamp:HH:mm:ss} [{Level:u3}] {Message:lj} <s:{SourceContext}>{NewLine}{Exception}";
                    configuration.WriteTo.ColoredConsole(outputTemplate: outputTemplate);
#endif
                }
            );
        }
    }
}