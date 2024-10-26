using Moq;
using Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Handlers.Generic;
using Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Interfaces;
using Patterns.DesignPatterns.Tests.Attributes;
using Serilog;

namespace Patterns.DesignPatterns.Tests.BehavioralPatterns.ChainOfResponsibilityPattern
{
    public class ConcreteHandlersTests
    {
        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.ChainOfResponsability)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void ConcreteHandlerA_Should_Handle_Request_A()
        {
            // Arrange
            var mockLogger = new Mock<ILogger>();
            var handlerA = new ConcreteHandlerA(mockLogger.Object);
            var mockHandlerB = new Mock<IHandler>();
            handlerA.SetNext(mockHandlerB.Object);

            // Act
            handlerA.HandleRequest("A");

            // Assert
            mockLogger.Verify(logger => logger.Information("ConcreteHandlerA handled request: A"), Times.Once);
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.ChainOfResponsability)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void ConcreteHandlerB_Should_Handle_Request_B()
        {
            // Arrange
            var mockLogger = new Mock<ILogger>();
            var handlerB = new ConcreteHandlerB(mockLogger.Object);
            var mockHandlerA = new Mock<IHandler>();
            handlerB.SetNext(mockHandlerA.Object);

            // Act
            handlerB.HandleRequest("B");

            // Assert
            mockLogger.Verify(logger => logger.Information("ConcreteHandlerB handled request: B"), Times.Once);
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.ChainOfResponsability)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void Handler_Should_Pass_Unhandled_Request_To_Next_Handler()
        {
            // Arrange
            var mockLogger = new Mock<ILogger>();
            var handlerA = new ConcreteHandlerA(mockLogger.Object);
            var handlerB = new ConcreteHandlerB(mockLogger.Object);
            handlerA.SetNext(handlerB);

            // Act
            handlerA.HandleRequest("B");

            // Assert
            mockLogger.Verify(logger => logger.Information("ConcreteHandlerB handled request: B"), Times.Once);
        }
    }
}
