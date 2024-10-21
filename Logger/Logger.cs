using Logger.Enums;
using Logger.Interfaces;

namespace Logger
{
    public class Logger : ILogger
    {
        private readonly string _logFilePath;
        private readonly LogLevel _minLogLevel;
        private readonly long _maxFileSizeInBytes;
        private static readonly object _lock = new object();

        public Logger(string logFilePath, LogLevel minLogLevel = LogLevel.Info, long maxFileSizeInBytes = 10 * 1024 * 1024) // Padrão: 10 MB
        {
            _logFilePath = logFilePath;
            _minLogLevel = minLogLevel;
            _maxFileSizeInBytes = maxFileSizeInBytes;
        }

        public void LogInfo(string message) => Log(LogLevel.Info, message);
        public void LogDebug(string message) => Log(LogLevel.Debug, message);
        public void LogWarning(string message) => Log(LogLevel.Warning, message);
        public void LogError(string message) => Log(LogLevel.Error, message);
        public void LogCritical(string message) => Log(LogLevel.Critical, message);

        private void Log(LogLevel level, string message)
        {
            if (level < _minLogLevel)
            {
                return; // Não loga se o nível de log for menor que o mínimo configurado
            }

            lock (_lock)
            {
                RotateLogFileIfNeeded(); // Verifica se é necessário rotacionar o arquivo

                var formattedMessage = FormatMessage(level, message);

                try
                {
                    // Grava o log no arquivo
                    File.AppendAllText(_logFilePath, formattedMessage + Environment.NewLine);
                } catch (Exception ex)
                {
                    Console.WriteLine($"Falha ao gravar log: {ex.Message}");
                }
            }
        }

        private void RotateLogFileIfNeeded()
        {
            var fileInfo = new FileInfo(_logFilePath);
            if (fileInfo.Exists && fileInfo.Length > _maxFileSizeInBytes)
            {
                string newFileName = $"{Path.GetFileNameWithoutExtension(_logFilePath)}_{DateTime.Now:yyyyMMddHHmmss}.log";
                string newFilePath = Path.Combine(fileInfo.DirectoryName, newFileName);
                File.Move(_logFilePath, newFilePath); // Renomeia o arquivo de log
            }
        }

        private string FormatMessage(LogLevel level, string message)
        {
            // Formatar a mensagem com o timestamp e o nível de log
            return $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
        }
    }
}
