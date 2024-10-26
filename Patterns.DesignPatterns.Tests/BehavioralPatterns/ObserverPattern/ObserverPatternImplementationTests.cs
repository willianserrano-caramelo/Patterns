using Moq;
using Patterns.DesignPatterns.BehavioralPatterns.ObserverPattern;
using Patterns.DesignPatterns.Tests.Attributes;
using Serilog;

namespace Patterns.DesignPatterns.Tests.BehavioralPatterns.ObserverPattern
{
    public class ObserverPatternImplementationTests
    {
        private readonly Mock<ILogger> _mockLogger;

        public ObserverPatternImplementationTests()
        {
            // Criar um Mock do Logger
            _mockLogger = new Mock<ILogger>();
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Observer)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void Should_NotifyConcreteObservers_When_MessageChanges()
        {
            _mockLogger.Object.Information("Iniciando teste Should_NotifyConcreteObservers_When_MessageChanges");

            // Arrange
            var subject = new Subject(_mockLogger.Object);
            var observerA = new ConcreteObserverA();
            var observerB = new ConcreteObserverB();

            // Act
            subject.RegisterObserver(observerA);
            subject.RegisterObserver(observerB);
            subject.ChangeMessage("Test Message");

            // Assert
            _mockLogger.Verify(logger => logger.Information(It.Is<string>(msg => msg.Contains("Notificando observer: ConcreteObserverA com a mensagem: Test Message"))), Times.Once);
            _mockLogger.Verify(logger => logger.Information(It.Is<string>(msg => msg.Contains("Notificando observer: ConcreteObserverB com a mensagem: Test Message"))), Times.Once);

            _mockLogger.Object.Information("Teste Should_NotifyConcreteObservers_When_MessageChanges finalizado com sucesso");
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Observer)]
        [PriorityTraits(Enums.TraitPriority.Medium)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void Should_OnlyNotifyRemainingConcreteObservers_When_OneObserverIsRemoved()
        {
            _mockLogger.Object.Information("Iniciando teste Should_OnlyNotifyRemainingConcreteObservers_When_OneObserverIsRemoved");

            // Arrange
            var subject = new Subject(_mockLogger.Object);
            var observerA = new ConcreteObserverA();
            var observerB = new ConcreteObserverB();

            subject.RegisterObserver(observerA);
            subject.RegisterObserver(observerB);

            // Act
            subject.RemoveObserver(observerA);
            subject.ChangeMessage("Another Test Message");

            // Assert
            _mockLogger.Verify(logger => logger.Information(It.Is<string>(msg => msg.Contains("Notificando observer: ConcreteObserverA com a mensagem: Test Message"))), Times.Never);
            _mockLogger.Verify(logger => logger.Information(It.Is<string>(msg => msg.Contains("Notificando observer: ConcreteObserverB com a mensagem: Another Test Message"))), Times.Once);

            _mockLogger.Object.Information("Teste Should_OnlyNotifyRemainingConcreteObservers_When_OneObserverIsRemoved finalizado com sucesso");
        }
    }
}
