using Moq;
using Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Handlers.ExpenseApproval;
using Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Interfaces;
using Patterns.DesignPatterns.Tests.Attributes;
using Serilog;

namespace Patterns.DesignPatterns.Tests.BehavioralPatterns.ChainOfResponsibilityPattern
{
    public class ApprovalHandlersTests
    {
        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.ChainOfResponsability)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void TeamManager_Should_Approve_Expense_Less_Than_1000()
        {
            // Arrange
            var mockLogger = new Mock<ILogger>();
            var teamManager = new TeamManagerHandler(mockLogger.Object);
            var mockDepartmentManager = new Mock<IHandler>();
            teamManager.SetNext(mockDepartmentManager.Object);

            // Act
            teamManager.HandleRequest(500m);

            // Assert
            mockLogger.Verify(logger => logger.Information("Gerente de Equipe aprovou a despesa de R$ 500"), Times.Once);
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.ChainOfResponsability)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void DepartmentManager_Should_Approve_Expense_Between_1000_And_10000()
        {
            // Arrange
            var mockLogger = new Mock<ILogger>();
            var departmentManager = new DepartmentManagerHandler(mockLogger.Object);
            var mockDirector = new Mock<IHandler>();
            departmentManager.SetNext(mockDirector.Object);

            // Act
            departmentManager.HandleRequest(5000m);

            // Assert
            mockLogger.Verify(logger => logger.Information("Gerente de Departamento aprovou a despesa de R$ 5000"), Times.Once);
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.ChainOfResponsability)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void Director_Should_Approve_Expense_Above_10000()
        {
            // Arrange
            var mockLogger = new Mock<ILogger>();
            var director = new DirectorHandler(mockLogger.Object);

            // Act
            director.HandleRequest(15000m);

            // Assert
            mockLogger.Verify(logger => logger.Information("Diretor aprovou a despesa de R$ 15000"), Times.Once);
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.ChainOfResponsability)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void Expense_Should_Pass_To_Next_Handler_If_Not_Handled()
        {
            // Arrange
            var mockLogger = new Mock<ILogger>();
            var teamManager = new TeamManagerHandler(mockLogger.Object);
            var departmentManager = new DepartmentManagerHandler(mockLogger.Object);
            var director = new DirectorHandler(mockLogger.Object);

            teamManager.SetNext(departmentManager).SetNext(director);

            // Act
            teamManager.HandleRequest(50000m);

            // Assert
            mockLogger.Verify(logger => logger.Information("Diretor aprovou a despesa de R$ 50000"), Times.Once);
        }
    }
}
