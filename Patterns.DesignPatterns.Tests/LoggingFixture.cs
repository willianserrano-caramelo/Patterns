using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Patterns.DesignPatterns.Tests
{
    public class LoggingFixture : IDisposable
    {
        public IServiceProvider ServiceProvider { get; }

        public LoggingFixture()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.test.json", optional: false, reloadOnChange: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            var serviceCollection = new ServiceCollection()
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.AddSerilog();
                });

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        // Método para retornar diretamente o Serilog.ILogger
        public Serilog.ILogger GetSerilogLogger() => Log.Logger;

        public void Dispose()
        {
            (ServiceProvider as IDisposable)?.Dispose();
            Log.CloseAndFlush();
        }
    }
}
