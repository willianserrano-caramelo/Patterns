using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.CalculationStrategies;
using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns.DesignPatterns.Exceptions;
using System.ComponentModel;
using Patterns.DesignPatterns.Tests.Attributes;

namespace Patterns.DesignPatterns.Tests.BehavioralPatterns.StrategyPattern
{
    public class StrategyPatternTests
    {
        [TypeTraits(Enums.TraitType.Unit)]
        [AreaTraits(Enums.TraitArea.MathOperations)]
        [PriorityTraits(Enums.TraitPriority.Low)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        [Fact]
        public void Test_AdditionStrategy()
        {
            // Arrange
            var calculator = new CalculationContext(new AdditionCalculationStrategy());

            // Act
            var result = calculator.ExecuteStrategy(5, 3);

            // Assert
            Assert.Equal("Resultado da Adição: 8", result);
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
    }
}
