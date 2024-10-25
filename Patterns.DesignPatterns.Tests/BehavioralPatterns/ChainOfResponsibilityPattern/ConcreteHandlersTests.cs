using Logger.Interfaces;
using Moq;
using Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Handlers.Generic;
using Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Interfaces;

namespace Patterns.DesignPatterns.Tests.BehavioralPatterns.ChainOfResponsibilityPattern
{
    public class ConcreteHandlersTests
    {
        [Fact]
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
            mockLogger.Verify(logger => logger.LogInfo("ConcreteHandlerA handled request: A"), Times.Once);
        }

        [Fact]
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
            mockLogger.Verify(logger => logger.LogInfo("ConcreteHandlerB handled request: B"), Times.Once);
        }

        [Fact]
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
            mockLogger.Verify(logger => logger.LogInfo("ConcreteHandlerB handled request: B"), Times.Once);
        }
    }
}
