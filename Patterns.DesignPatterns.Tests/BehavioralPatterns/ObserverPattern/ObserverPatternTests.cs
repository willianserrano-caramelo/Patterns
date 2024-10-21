using Patterns.DesignPatterns.BehavioralPatterns.ObserverPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Patterns.DesignPatterns.BehavioralPatterns.ObserverPattern;
using Patterns.DesignPatterns.Tests.Attributes;
using Logger.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Patterns.DesignPatterns.Tests.BehavioralPatterns.ObserverPattern
{
    public class ObserverPatternTests: IClassFixture<ServiceProviderFixture>
    {

        private readonly ILogger _logger;
        private readonly Mock<ILogger> _mockLogger;

        public ObserverPatternTests(ServiceProviderFixture fixture)
        {
            _logger = fixture.ServiceProvider.GetRequiredService<ILogger>();
            _mockLogger = new Mock<ILogger>();
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Observer)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void Should_RegisterObserverAndNotifyAllObservers_When_MessageChanges()
        {
            _logger.LogInfo("Iniciando teste Should_RegisterObserverAndNotifyAllObservers_When_MessageChanges");
            _mockLogger.Object.LogInfo("Iniciando teste Should_RegisterObserverAndNotifyAllObservers_When_MessageChanges");

            // Arrange
            var subject = new Subject(_mockLogger.Object);

            var mockObserverA = new Mock<IObserver>();
            var mockObserverB = new Mock<IObserver>();

            // Act
            subject.RegisterObserver(mockObserverA.Object);
            subject.RegisterObserver(mockObserverB.Object);
            subject.ChangeMessage("Test Message");

            // Assert
            mockObserverA.Verify(observer => observer.Update(It.IsAny<string>()), Times.Once);
            mockObserverB.Verify(observer => observer.Update(It.IsAny<string>()), Times.Once);

            _logger.LogInfo("Teste Should_RegisterObserverAndNotifyAllObservers_When_MessageChanges finalizado com sucesso");
            _mockLogger.Object.LogInfo("Teste Should_RegisterObserverAndNotifyAllObservers_When_MessageChanges finalizado com sucesso");
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Observer)]
        [PriorityTraits(Enums.TraitPriority.Medium)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void Should_RemoveObserver_AndOnlyNotifyRemainingObservers()
        {
            _logger.LogInfo("Iniciando teste Should_RemoveObserver_AndOnlyNotifyRemainingObservers");
            _mockLogger.Object.LogInfo("Iniciando teste Should_RemoveObserver_AndOnlyNotifyRemainingObservers");

            // Arrange
            var subject = new Subject(_mockLogger.Object);

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

            _logger.LogInfo("Teste Should_RemoveObserver_AndOnlyNotifyRemainingObservers finalizado com sucesso");
            _mockLogger.Object.LogInfo("Teste Should_RemoveObserver_AndOnlyNotifyRemainingObservers finalizado com sucesso");
        }
    }
}
