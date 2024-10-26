using Moq;
using Patterns.DesignPatterns.BehavioralPatterns.IteratorPattern;
using Patterns.DesignPatterns.BehavioralPatterns.IteratorPattern.Model;
using Serilog;

namespace Patterns.DesignPatterns.Tests.BehavioralPatterns.IteratorPattern
{
    public class MusicPlaylistTests
    {
        private readonly Mock<ILogger> _mockLogger;
        private readonly MusicPlaylist _playlist;

        public MusicPlaylistTests()
        {
            _mockLogger = new Mock<ILogger>();
            _playlist = new MusicPlaylist(_mockLogger.Object);
        }

        [Fact]
        public void MusicIterator_ShouldPlayAllSongs()
        {
            // Arrange
            _playlist.AddSong(new Song("Song 1", "Artist A"));
            _playlist.AddSong(new Song("Song 2", "Artist B"));
            var iterator = _playlist.CreateIterator();

            // Act & Assert
            Assert.True(iterator.HasNext());
            Assert.Equal("Song 1 by Artist A", iterator.Next().ToString());
            Assert.True(iterator.HasNext());
            Assert.Equal("Song 2 by Artist B", iterator.Next().ToString());
            Assert.False(iterator.HasNext());

            // Verify log calls
            _mockLogger.Verify(log => log.Information(It.Is<string>(s => s.Contains("Added song:"))), Times.Exactly(2));
            _mockLogger.Verify(log => log.Information(It.Is<string>(s => s.Contains("Playing song:"))), Times.Exactly(2));
        }

        [Fact]
        public void MusicIterator_ShouldThrowException_WhenNoMoreSongs()
        {
            // Arrange
            var iterator = _playlist.CreateIterator();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => iterator.Next());

            // Verify log call
            _mockLogger.Verify(log => log.Error("No more songs in the playlist."), Times.Once);
        }
    }
}
