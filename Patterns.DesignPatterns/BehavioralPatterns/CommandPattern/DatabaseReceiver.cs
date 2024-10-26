using Serilog;

namespace Patterns.DesignPatterns.BehavioralPatterns.CommandPattern
{
    public class DatabaseReceiver
    {
        private readonly Dictionary<int, string> _database = new Dictionary<int, string>();
        private readonly ILogger _logger;

        public DatabaseReceiver(ILogger logger)
        {
            _logger = logger;
        }

        public void CreateRecord(int id, string data)
        {
            _database[id] = data;
            _logger.Information($"Record with ID {id} created.");
        }

        public string ReadRecord(int id)
        {
            _database.TryGetValue(id, out var data);
            _logger.Information($"Record with ID {id} read: {data}");
            return data;
        }

        public void UpdateRecord(int id, string newData)
        {
            if (_database.ContainsKey(id))
            {
                _database[id] = newData;
                _logger.Information($"Record with ID {id} updated.");
            }
        }

        public void DeleteRecord(int id)
        {
            if (_database.ContainsKey(id))
            {
                _database.Remove(id);
                _logger.Information($"Record with ID {id} deleted.");
            }
        }
    }

}
