using Logger.Enums;
using Logger.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.Tests
{
    public class ServiceProviderFixture : IDisposable
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public ServiceProviderFixture()
        {
            // Configurar o contêiner de DI
            var serviceCollection = new ServiceCollection();

            // Carregar as configurações do appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.test.json")
                .Build();

            // Registrar o Logger como serviço
            serviceCollection.AddSingleton<ILogger>(provider =>
            {
                string relativeLogFilePath = configuration["Logging:LogFilePath"];
                string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeLogFilePath);

                LogLevel minLogLevel = Enum.Parse<LogLevel>(configuration["Logging:MinLogLevel"]);
                long maxFileSizeInBytes = long.Parse(configuration["Logging:MaxFileSizeInMB"]) * 1024 * 1024;

                return new Logger.Logger(logFilePath, minLogLevel, maxFileSizeInBytes);
            });

            // Construir o provedor de serviços
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public void Dispose()
        {
            // Limpar recursos, se necessário
            ((IDisposable)ServiceProvider)?.Dispose();
        }
    }
}
