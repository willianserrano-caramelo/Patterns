using Logger.Enums;
using Logger.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Logger.Tests
{
    public class LoggerTests
    {
        private readonly IConfiguration _configuration;

        public LoggerTests()
        {
            // Configuração para carregar o appsettings.json
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Diretório atual
                .AddJsonFile("appsettings.test.json") // Carrega o appsettings.json
                .Build();
        }

        [Fact]
        public void TestLoggerWithRelativePath()
        {
            string relativeLogFilePath = _configuration["Logging:LogFilePath"];
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeLogFilePath);

            LogLevel minLogLevel = Enum.Parse<LogLevel>(_configuration["Logging:MinLogLevel"]);
            long maxFileSizeInBytes = long.Parse(_configuration["Logging:MaxFileSizeInMB"]) * 1024 * 1024;

            ILogger logger = new Logger(logFilePath, minLogLevel, maxFileSizeInBytes);
            logger.LogInfo("Testando o Logger com caminho relativo");
        }
    }
}