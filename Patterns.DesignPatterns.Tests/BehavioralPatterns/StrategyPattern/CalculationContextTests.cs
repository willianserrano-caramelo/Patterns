using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern;
using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.CalculationStrategies;
using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.Interfaces;
using Patterns.DesignPatterns.Exceptions;
using Patterns.DesignPatterns.Tests.Attributes;

namespace Patterns.DesignPatterns.Tests.BehavioralPatterns.StrategyPattern
{
    public class CalculationContextTests
    {
        [TypeTraits(Enums.TraitType.Unit)]
        [AreaTraits(Enums.TraitArea.MathOperations)]
        [PriorityTraits(Enums.TraitPriority.Low)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        [Theory]
        [InlineData(5, 3, "Resultado da Adição: 8")]
        public void Test_AdditionStrategy(int a, int b, string expected)
        {
            // Arrange
            var calculator = new CalculationContext(new AdditionCalculationStrategy());

            // Act
            var result = calculator.ExecuteStrategy(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [TypeTraits(Enums.TraitType.Unit)]
        [AreaTraits(Enums.TraitArea.MathOperations)]
        [PriorityTraits(Enums.TraitPriority.Low)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        [Fact]
        public void Test_SubtractionStrategy()
        {
            // Arrange
            var calculator = new CalculationContext(new SubtractionCalculationStrategy());

            // Act
            var result = calculator.ExecuteStrategy(5, 3);

            // Assert
            Assert.Equal("Resultado da Subtração: 2", result);
        }

        [TypeTraits(Enums.TraitType.Unit)]
        [AreaTraits(Enums.TraitArea.MathOperations)]
        [PriorityTraits(Enums.TraitPriority.Low)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Error)]
        [Fact]
        public void Test_NegativeNumber_ThrowsException()
        {
            // Arrange
            var calculator = new CalculationContext(new SubtractionCalculationStrategy());

            // Act & Assert
            Assert.Throws<NegativeNumberException>(() => calculator.ExecuteStrategy(-5, 3));
        }

        [TypeTraits(Enums.TraitType.Unit)]
        [AreaTraits(Enums.TraitArea.MathOperations)]
        [PriorityTraits(Enums.TraitPriority.Low)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        [Fact]
        public void Test_MultiplicationStrategy()
        {
            // Arrange
            var calculator = new CalculationContext(new MultiplicationCalculationStrategy());

            // Act
            var result = calculator.ExecuteStrategy(5, 3);

            // Assert
            Assert.Equal("Resultado da Multiplicação: 15", result);
        }

        [TypeTraits(Enums.TraitType.Unit)]
        [AreaTraits(Enums.TraitArea.MathOperations)]
        [PriorityTraits(Enums.TraitPriority.Low)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        [Fact]
        public void Test_DivisionStrategy()
        {
            // Arrange
            var calculator = new CalculationContext(new DivisionCalculationStrategy());

            // Act
            var result = calculator.ExecuteStrategy(6, 3);

            // Assert
            Assert.Equal("Resultado da Divisão: 2", result);
        }

        [TypeTraits(Enums.TraitType.Unit)]
        [AreaTraits(Enums.TraitArea.MathOperations)]
        [PriorityTraits(Enums.TraitPriority.Low)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Error)]
        [Fact]
        public void Test_DivisionByZero_ThrowsException()
        {
            // Arrange
            var calculator = new CalculationContext(new DivisionCalculationStrategy());

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => calculator.ExecuteStrategy(6, 0));
        }

        [TypeTraits(Enums.TraitType.Unit)]
        [AreaTraits(Enums.TraitArea.MathOperations)]
        [PriorityTraits(Enums.TraitPriority.Low)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        [Fact]
        public void Test_ChangeStrategy()
        {
            // Arrange
            var calculator = new CalculationContext(new AdditionCalculationStrategy());
            calculator.SetStrategy(new SubtractionCalculationStrategy());

            // Act
            var result = calculator.ExecuteStrategy(5, 3);

            // Assert
            Assert.Equal("Resultado da Subtração: 2", result);
        }

        [TypeTraits(Enums.TraitType.Unit)]
        [AreaTraits(Enums.TraitArea.MathOperations)]
        [PriorityTraits(Enums.TraitPriority.Low)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        [Theory]
        [InlineData(5, 3, "Resultado da Multiplicação: 15")]
        [InlineData(6, 3, "Resultado da Divisão: 2")]
        public void Test_Operations(int a, int b, string expected)
        {
            // Arrange
            var strategy = a == 6 ? (ICalculationStrategy)new DivisionCalculationStrategy() : new MultiplicationCalculationStrategy();
            var calculator = new CalculationContext(strategy);

            // Act
            var result = calculator.ExecuteStrategy(a, b);

            // Assert
            Assert.Equal(expected, result);
        }
        
        [TypeTraits(Enums.TraitType.Unit)]
        [AreaTraits(Enums.TraitArea.MathOperations)]
        [PriorityTraits(Enums.TraitPriority.Low)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Error)]
        [Theory]
        [InlineData(-5, 3, typeof(SubtractionCalculationStrategy), typeof(NegativeNumberException))]
        [InlineData(6, 0, typeof(DivisionCalculationStrategy), typeof(DivideByZeroException))]
        public void Test_CalculationStrategy_ThrowsException(int a, int b, Type strategyType, Type expectedException)
        {
            // Arrange
            var strategy = (ICalculationStrategy)Activator.CreateInstance(strategyType);
            var calculator = new CalculationContext(strategy);

            // Act & Assert
            Assert.Throws(expectedException, () => calculator.ExecuteStrategy(a, b));
        }
    }
}
