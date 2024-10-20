using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.CalculationStrategies;
using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.Tests.BehavioralPatterns.StrategyPattern
{
    public class StrategyPatternTests
    {
        [Fact]
        public void Test_AdditionStrategy()
        {
            // Arrange
            var calculator = new CalculationContext(new AdditionStrategy());

            // Act
            var result = calculator.ExecuteStrategy(5, 3);

            // Assert
            Assert.Equal("Resultado da Adição: 8", result);
        }

        [Fact]
        public void Test_SubtractionStrategy()
        {
            // Arrange
            var calculator = new CalculationContext(new SubtractionStrategy());

            // Act
            var result = calculator.ExecuteStrategy(5, 3);

            // Assert
            Assert.Equal("Resultado da Subtração: 2", result);
        }

        [Fact]
        public void Test_NegativeNumbers_SubtractionStrategy()
        {
            // Arrange
            var calculator = new CalculationContext(new SubtractionStrategy());

            // Act
            var result = calculator.ExecuteStrategy(-5, 3);

            // Assert
            Assert.Equal("Erro: Números negativos não são permitidos!", result);
        }

        [Fact]
        public void Test_MultiplicationStrategy()
        {
            // Arrange
            var calculator = new CalculationContext(new MultiplicationStrategy());

            // Act
            var result = calculator.ExecuteStrategy(5, 3);

            // Assert
            Assert.Equal("Resultado da Multiplicação: 15", result);
        }

        [Fact]
        public void Test_DivisionStrategy()
        {
            // Arrange
            var calculator = new CalculationContext(new DivisionStrategy());

            // Act
            var result = calculator.ExecuteStrategy(6, 3);

            // Assert
            Assert.Equal("Resultado da Divisão: 2", result);
        }

        [Fact]
        public void Test_DivisionByZero()
        {
            // Arrange
            var calculator = new CalculationContext(new DivisionStrategy());

            // Act
            var result = calculator.ExecuteStrategy(6, 0);

            // Assert
            Assert.Equal("Erro: Divisão por zero!", result);
        }

        [Fact]
        public void Test_ChangeStrategy()
        {
            // Arrange
            var calculator = new CalculationContext(new AdditionStrategy());
            calculator.SetStrategy(new SubtractionStrategy());

            // Act
            var result = calculator.ExecuteStrategy(5, 3);

            // Assert
            Assert.Equal("Resultado da Subtração: 2", result);
        }
    }
}
