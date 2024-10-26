using Serilog;

namespace Patterns.DesignPatterns.BehavioralPatterns.CommandPattern
{
    public class FileReceiver
    {
        private readonly ILogger _logger;

        public FileReceiver(ILogger logger)
        {
            _logger = logger;
        }

        public void CreateFile(string filePath)
        {
            File.Create(filePath).Dispose();
            _logger.Information($"File created at {filePath}");
        }

        public void EditFile(string filePath, string content)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file at {filePath} was not found.");
            }

            File.WriteAllText(filePath, content);
            _logger.Information($"File at {filePath} edited with new content.");
        }

        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                _logger.Information($"File at {filePath} deleted.");
            }
        }

        public void RecoverFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
            _logger.Information($"File at {filePath} edited with new content.");
        }
    }

}
