using Moq;
using Patterns.DesignPatterns.BehavioralPatterns.ObserverPattern;
using Patterns.DesignPatterns.BehavioralPatterns.ObserverPattern.Interfaces;
using Patterns.DesignPatterns.Tests.Attributes;
using Serilog;
using Xunit;

namespace Patterns.DesignPatterns.Tests.BehavioralPatterns.ObserverPattern
{
    public class ObserverPatternTests : IClassFixture<LoggingFixture>
    {
        private readonly ILogger _logger;

        public ObserverPatternTests(LoggingFixture fixture)
        {
            _logger = fixture.GetSerilogLogger();
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Observer)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void Should_RegisterObserverAndNotifyAllObservers_When_MessageChanges()
        {
            _logger.Information("Iniciando teste Should_RegisterObserverAndNotifyAllObservers_When_MessageChanges");

            // Arrange
            var subject = new Subject(_logger);

            var mockObserverA = new Mock<IObserver>();
            var mockObserverB = new Mock<IObserver>();

            // Act
            subject.RegisterObserver(mockObserverA.Object);
            subject.RegisterObserver(mockObserverB.Object);
            subject.ChangeMessage("Test Message");

            // Assert
            mockObserverA.Verify(observer => observer.Update(It.IsAny<string>()), Times.Once);
            mockObserverB.Verify(observer => observer.Update(It.IsAny<string>()), Times.Once);

            _logger.Information("Teste Should_RegisterObserverAndNotifyAllObservers_When_MessageChanges finalizado com sucesso");
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Observer)]
        [PriorityTraits(Enums.TraitPriority.Medium)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void Should_RemoveObserver_AndOnlyNotifyRemainingObservers()
        {
            _logger.Information("Iniciando teste Should_RemoveObserver_AndOnlyNotifyRemainingObservers");

            // Arrange
            var subject = new Subject(_logger);

            var mockObserverA = new Mock<IObserver>();
            var mockObserverB = new Mock<IObserver>();

            subject.RegisterObserver(mockObserverA.Object);
            subject.RegisterObserver(mockObserverB.Object);

            // Act
            subject.RemoveObserver(mockObserverA.Object);
            subject.ChangeMessage("Another Test Message");

            // Assert
            mockObserverA.Verify(observer => observer.Update(It.IsAny<string>()), Times.Never);
            mockObserverB.Verify(observer => observer.Update(It.IsAny<string>()), Times.Once);

            _logger.Information("Teste Should_RemoveObserver_AndOnlyNotifyRemainingObservers finalizado com sucesso");
        }
    }
}
