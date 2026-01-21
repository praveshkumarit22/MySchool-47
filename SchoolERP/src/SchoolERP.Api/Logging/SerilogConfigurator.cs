using Serilog;
using Serilog.Events;

namespace SchoolERP.Api.Logging;

public static class SerilogConfigurator
{
    public static void Configure()
    {
        Log.Logger = new LoggerConfiguration()

            // Global minimum level
            .MinimumLevel.Information()

            // Reduce framework noise
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)

            // Adds RequestId, TraceId, etc.
            .Enrich.FromLogContext()

            // Console logging
            .WriteTo.Console()

            // Daily rolling file logs
            .WriteTo.File(
                path: "Logs/log-.txt",
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 30)

            .CreateLogger();
    }
}
