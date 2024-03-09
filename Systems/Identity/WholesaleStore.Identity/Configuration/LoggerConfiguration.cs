using Serilog;
using Serilog.Events;
using WholesaleStore.Services.Settings;

namespace WholesaleStore.Identity.Configuration;

public static class LoggerConfiguration
{
    public static void AddAppLogger(this WebApplicationBuilder builder,
        LoggerSettings logSettings)
    {
        var loggerConfiguration = new Serilog.LoggerConfiguration();

        // Base configuration
        loggerConfiguration
            .Enrich.WithCorrelationIdHeader()
            .Enrich.FromLogContext();

        // Log level
        if (!Enum.TryParse(logSettings.Level, out LoggerLevel level)) level = LoggerLevel.Information;

        ;

        var serilogLevel = level switch
        {
            LoggerLevel.Verbose => LogEventLevel.Verbose,
            LoggerLevel.Debug => LogEventLevel.Debug,
            LoggerLevel.Information => LogEventLevel.Information,
            LoggerLevel.Warning => LogEventLevel.Warning,
            LoggerLevel.Error => LogEventLevel.Error,
            LoggerLevel.Fatal => LogEventLevel.Fatal,
            _ => LogEventLevel.Information
        };

        loggerConfiguration
            .MinimumLevel.Is(serilogLevel)
            .MinimumLevel.Override("Microsoft", serilogLevel)
            .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", serilogLevel)
            .MinimumLevel.Override("System", serilogLevel)
            ;

        // Writers
        var logItemTemplate =
            "[{Timestamp:HH:mm:ss:fff} {Level:u3} ({CorrelationId})] {Message:lj}{NewLine}{Exception}";

        // Writing to Console configuration 
        if (logSettings.WriteToConsole)
            loggerConfiguration.WriteTo.Console(
                serilogLevel,
                logItemTemplate
            );

        // Writing to File configuration 
        if (logSettings.WriteToFile)
        {
            if (!Enum.TryParse(logSettings.FileRollingInterval, out LoggerRollingInterval interval))
                interval = LoggerRollingInterval.Day;

            var serilogInterval = interval switch
            {
                LoggerRollingInterval.Infinite => RollingInterval.Infinite,
                LoggerRollingInterval.Year => RollingInterval.Year,
                LoggerRollingInterval.Month => RollingInterval.Month,
                LoggerRollingInterval.Day => RollingInterval.Day,
                LoggerRollingInterval.Hour => RollingInterval.Hour,
                LoggerRollingInterval.Minute => RollingInterval.Minute,
                _ => RollingInterval.Day
            };

            if (!int.TryParse(logSettings.FileRollingSize, out var size))
                size = 5242880;

            var fileName = $"_.log";

            loggerConfiguration.WriteTo.File($"logs/{fileName}",
                serilogLevel,
                logItemTemplate,
                rollingInterval: serilogInterval,
                rollOnFileSizeLimit: true,
                fileSizeLimitBytes: size
            );
        }

        // Make logger
        var logger = loggerConfiguration.CreateLogger();


        // Apply logger to application
        builder.Host.UseSerilog(logger, true);
    }
}
