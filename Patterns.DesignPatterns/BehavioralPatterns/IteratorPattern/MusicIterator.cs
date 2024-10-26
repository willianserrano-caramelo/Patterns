using Patterns.DesignPatterns.BehavioralPatterns.IteratorPattern.Interfaces;
using Patterns.DesignPatterns.BehavioralPatterns.IteratorPattern.Model;
using Serilog;

namespace Patterns.DesignPatterns.BehavioralPatterns.IteratorPattern
{
    public class MusicIterator : IMusicIterator
    {
        private readonly List<Song> _songs;
        private int _position = 0;
        private readonly ILogger _logger;

        public MusicIterator(List<Song> songs, ILogger logger)
        {
            _songs = songs;
            _logger = logger;
        }

        public bool HasNext()
        {
            bool hasNext = _position < _songs.Count;
            _logger.Information($"Checking if there's a next song: {hasNext}");
            return hasNext;
        }

        public Song Next()
        {
            if (!HasNext())
            {
                _logger.Error("No more songs in the playlist.");
                throw new InvalidOperationException("No more songs.");
            }

            Song song = _songs[_position++];
            _logger.Information($"Playing song: {song}");
            return song;
        }
    }
}
