using Patterns.DesignPatterns.BehavioralPatterns.IteratorPattern.Interfaces;
using Patterns.DesignPatterns.BehavioralPatterns.IteratorPattern.Model;
using Serilog;

namespace Patterns.DesignPatterns.BehavioralPatterns.IteratorPattern
{
    public class MusicPlaylist : IMusicPlaylist
    {
        private readonly List<Song> _songs = new List<Song>();
        private readonly ILogger _logger;

        public MusicPlaylist(ILogger logger)
        {
            _logger = logger;
        }

        public void AddSong(Song song)
        {
            _songs.Add(song);
            _logger.Information($"Added song: {song}");
        }

        public IMusicIterator CreateIterator()
        {
            return new MusicIterator(_songs, _logger);
        }
    }
}
