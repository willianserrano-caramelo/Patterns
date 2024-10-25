using Logger.Interfaces;
using Moq;
using Patterns.DesignPatterns.BehavioralPatterns.ObserverPattern;
using Patterns.DesignPatterns.Tests.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _mockLogger.Object.LogInfo("Iniciando teste Should_NotifyConcreteObservers_When_MessageChanges");

            // Arrange
            var subject = new Subject(_mockLogger.Object);
            var observerA = new ConcreteObserverA();
            var observerB = new ConcreteObserverB();

            // Act
            subject.RegisterObserver(observerA);
            subject.RegisterObserver(observerB);
            subject.ChangeMessage("Test Message");

            // Assert
            _mockLogger.Verify(logger => logger.LogInfo(It.Is<string>(msg => msg.Contains("Notificando observer: ConcreteObserverA com a mensagem: Test Message"))), Times.Once);
            _mockLogger.Verify(logger => logger.LogInfo(It.Is<string>(msg => msg.Contains("Notificando observer: ConcreteObserverB com a mensagem: Test Message"))), Times.Once);

            _mockLogger.Object.LogInfo("Teste Should_NotifyConcreteObservers_When_MessageChanges finalizado com sucesso");
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Observer)]
        [PriorityTraits(Enums.TraitPriority.Medium)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void Should_OnlyNotifyRemainingConcreteObservers_When_OneObserverIsRemoved()
        {
            _mockLogger.Object.LogInfo("Iniciando teste Should_OnlyNotifyRemainingConcreteObservers_When_OneObserverIsRemoved");

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
            _mockLogger.Verify(logger => logger.LogInfo(It.Is<string>(msg => msg.Contains("Notificando observer: ConcreteObserverA com a mensagem: Test Message"))), Times.Never);
            _mockLogger.Verify(logger => logger.LogInfo(It.Is<string>(msg => msg.Contains("Notificando observer: ConcreteObserverB com a mensagem: Another Test Message"))), Times.Once);

            _mockLogger.Object.LogInfo("Teste Should_OnlyNotifyRemainingConcreteObservers_When_OneObserverIsRemoved finalizado com sucesso");
        }
    }
}
