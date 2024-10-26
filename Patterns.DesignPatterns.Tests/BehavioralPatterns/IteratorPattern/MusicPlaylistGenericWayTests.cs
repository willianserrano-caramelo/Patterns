using Moq;
using Patterns.DesignPatterns.BehavioralPatterns.IteratorPattern.Model;
using Patterns.DesignPatterns.BehavioralPatterns.IteratorPattern;
using Serilog;
using System;
using Xunit;

namespace Patterns.DesignPatterns.Tests.BehavioralPatterns.IteratorPattern
{
    public class MusicPlaylistGenericWayTests
    {
        private readonly Mock<ILogger> _mockLogger;
        private readonly MusicPlaylistGenericWay<Song> _playlist;

        public MusicPlaylistGenericWayTests()
        {
            _mockLogger = new Mock<ILogger>();
            _playlist = new MusicPlaylistGenericWay<Song>(_mockLogger.Object);
        }

        [Fact]
        public void MusicIteratorGenericWay_ShouldIterateAllSongs()
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
            _mockLogger.Verify(log => log.Information(It.Is<string>(s => s.Contains("Returning item at position"))), Times.Exactly(2));
        }

        [Fact]
        public void MusicIteratorGenericWay_ShouldThrowException_WhenNoMoreSongs()
        {
            // Arrange
            var iterator = _playlist.CreateIterator();

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => iterator.Next());
            Assert.Equal("No more items.", exception.Message);

            // Verify log call
            _mockLogger.Verify(log => log.Error("No more items in the collection."), Times.Once);
        }

        [Fact]
        public void MusicIteratorGenericWay_ShouldReturnFalse_WhenPlaylistIsEmpty()
        {
            // Arrange
            var iterator = _playlist.CreateIterator();

            // Act
            bool hasNext = iterator.HasNext();

            // Assert
            Assert.False(hasNext);
            _mockLogger.Verify(log => log.Information("Checking if there's a next item: False"), Times.Once);
        }

        [Fact]
        public void MusicIteratorGenericWay_ShouldReturnTrue_WhenPlaylistHasSongs()
        {
            // Arrange
            _playlist.AddSong(new Song("Song 1", "Artist A"));
            var iterator = _playlist.CreateIterator();

            // Act
            bool hasNext = iterator.HasNext();

            // Assert
            Assert.True(hasNext);
            _mockLogger.Verify(log => log.Information("Checking if there's a next item: True"), Times.Once);
        }
    }
}
