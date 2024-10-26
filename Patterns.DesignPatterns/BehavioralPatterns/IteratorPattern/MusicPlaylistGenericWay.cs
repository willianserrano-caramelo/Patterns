using Patterns.DesignPatterns.BehavioralPatterns.IteratorPattern.Interfaces;
using Serilog;
using System.Collections.Generic;

namespace Patterns.DesignPatterns.BehavioralPatterns.IteratorPattern
{
    public class MusicPlaylistGenericWay<T> : IAggregate<T>
    {
        private readonly List<T> _songs = new List<T>();
        private readonly ILogger _logger;

        public MusicPlaylistGenericWay(ILogger logger)
        {
            _logger = logger;
        }

        public void AddSong(T song)
        {
            _songs.Add(song);
            _logger.Information($"Added song: {song}");
        }

        public IIterator<T> CreateIterator()
        {
            return new MusicIteratorGenericWay<T>(_songs, _logger);
        }
    }
}
