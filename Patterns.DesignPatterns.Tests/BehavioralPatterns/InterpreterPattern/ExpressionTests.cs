using Moq;
using Patterns.DesignPatterns.BehavioralPatterns.InterpreterPattern.Expressions;
using Patterns.DesignPatterns.BehavioralPatterns.InterpreterPattern.Interfaces;
using Patterns.DesignPatterns.Tests.Attributes;
using Serilog;

namespace Patterns.DesignPatterns.Tests.BehavioralPatterns.InterpreterPattern
{
    public class ExpressionTests
    {
        private readonly Mock<ILogger> _mockLogger;

        public ExpressionTests()
        {
            _mockLogger = new Mock<ILogger>();
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Interpreter)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void AddExpression_ShouldReturnCorrectSum()
        {
            var left = CreateNumberExpression(5);
            var right = CreateNumberExpression(3);
            var addExpression = new AddExpression(left, right, _mockLogger.Object);

            double result = addExpression.Interpret();

            Assert.Equal(8, result);
            _mockLogger.Verify(log => log.Information("Adding 5 + 3"), Times.Once);
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Interpreter)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void SubtractExpression_ShouldReturnCorrectDifference()
        {
            var left = CreateNumberExpression(10);
            var right = CreateNumberExpression(4);
            var subtractExpression = new SubtractExpression(left, right, _mockLogger.Object);

            double result = subtractExpression.Interpret();

            Assert.Equal(6, result);
            _mockLogger.Verify(log => log.Information("Subtracting 10 - 4"), Times.Once);
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Interpreter)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void MultiplyExpression_ShouldReturnCorrectProduct()
        {
            var left = CreateNumberExpression(6);
            var right = CreateNumberExpression(7);
            var multiplyExpression = new MultiplyExpression(left, right, _mockLogger.Object);

            double result = multiplyExpression.Interpret();

            Assert.Equal(42, result);
            _mockLogger.Verify(log => log.Information("Multiplying 6 * 7"), Times.Once);
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Interpreter)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        public void DivideExpression_ShouldReturnCorrectQuotient()
        {
            var left = CreateNumberExpression(8);
            var right = CreateNumberExpression(2);
            var divideExpression = new DivideExpression(left, right, _mockLogger.Object);

            double result = divideExpression.Interpret();

            Assert.Equal(4, result);
            _mockLogger.Verify(log => log.Information("Dividing 8 / 2"), Times.Once);
        }

        [Fact]
        [TypeTraits(Enums.TraitType.Unit)]
        [PatternTraits(Enums.TraitPattern.Interpreter)]
        [PriorityTraits(Enums.TraitPriority.High)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Error)]
        public void DivideExpression_ShouldThrowException_WhenDividingByZero()
        {
            var left = CreateNumberExpression(10);
            var right = CreateNumberExpression(0);
            var divideExpression = new DivideExpression(left, right, _mockLogger.Object);

            var exception = Assert.Throws<DivideByZeroException>(() => divideExpression.Interpret());
            Assert.Equal("Cannot divide by zero.", exception.Message);

            _mockLogger.Verify(log => log.Error("Attempted to divide by zero."), Times.Once);
        }

        private IExpression CreateNumberExpression(double value) => new NumberExpression(value, _mockLogger.Object);
    }
}
