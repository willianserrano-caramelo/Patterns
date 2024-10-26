using Patterns.DesignPatterns.BehavioralPatterns.IteratorPattern.Interfaces;
using Serilog;

namespace Patterns.DesignPatterns.BehavioralPatterns.IteratorPattern
{
    public class MusicIteratorGenericWay<T> : IIterator<T>
    {
        private readonly List<T> _collection;
        private int _position = 0;
        private readonly ILogger _logger;

        public MusicIteratorGenericWay(List<T> collection, ILogger logger)
        {
            _collection = collection;
            _logger = logger;
        }

        public bool HasNext()
        {
            bool hasNext = _position < _collection.Count;
            _logger.Information($"Checking if there's a next item: {hasNext}");
            return hasNext;
        }

        public T Next()
        {
            if (!HasNext())
            {
                _logger.Error("No more items in the collection.");
                throw new InvalidOperationException("No more items.");
            }

            T item = _collection[_position++];
            _logger.Information($"Returning item at position {_position - 1}: {item}");
            return item;
        }
    }
}
