using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern;
using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.Interfaces;
using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.PaymentStrategies;
using Patterns.DesignPatterns.Tests.Attributes;

namespace Patterns.DesignPatterns.Tests.BehavioralPatterns.StrategyPattern
{
    public class PaymentContextTests
    {
        [TypeTraits(Enums.TraitType.Unit)]
        [AreaTraits(Enums.TraitArea.Payments)]
        [PriorityTraits(Enums.TraitPriority.Low)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        [Fact]
        public void Test_CreditCardPaymentStrategy()
        {
            // Arrange
            var paymentContext = new PaymentContext(new CreditCardPaymentStrategy());

            // Act
            var result = paymentContext.ProcessOrderPayment(100.00m);

            // Assert
            Assert.Equal("Pagamento de R$100,00 processado via Cartão de Crédito.", result);
        }

        [TypeTraits(Enums.TraitType.Unit)]
        [AreaTraits(Enums.TraitArea.Payments)]
        [PriorityTraits(Enums.TraitPriority.Low)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        [Fact]
        public void Test_PayPalPaymentStrategy()
        {
            // Arrange
            var paymentContext = new PaymentContext(new PayPalPaymentStrategy());

            // Act
            var result = paymentContext.ProcessOrderPayment(200.00m);

            // Assert
            Assert.Equal("Pagamento de R$200,00 processado via PayPal.", result);
        }

        [TypeTraits(Enums.TraitType.Unit)]
        [AreaTraits(Enums.TraitArea.Payments)]
        [PriorityTraits(Enums.TraitPriority.Low)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        [Theory]
        [InlineData(100.00, "Nenhuma estratégia de pagamento foi definida.")]
        public void Test_NullPaymentStrategy_DefaultBehavior(decimal amount, string expected)
        {
            // Arrange
            var paymentContext = new PaymentContext();

            // Act
            var result = paymentContext.ProcessOrderPayment(amount);

            // Assert
            Assert.Equal(expected, result);
        }
        
        [TypeTraits(Enums.TraitType.Unit)]
        [AreaTraits(Enums.TraitArea.Payments)]
        [PriorityTraits(Enums.TraitPriority.Low)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        [Theory]
        [InlineData(100.00, "Nenhuma estratégia de pagamento foi definida.")]
        public void Test_SetNullPaymentStrategy_UsesNullStrategy(decimal amount, string expected)
        {
            // Arrange
            var paymentContext = new PaymentContext(new CreditCardPaymentStrategy());

            // Act
            paymentContext.SetPaymentStrategy(null);
            var result = paymentContext.ProcessOrderPayment(amount);

            // Assert
            Assert.Equal(expected, result);
        }

        [TypeTraits(Enums.TraitType.Unit)]
        [AreaTraits(Enums.TraitArea.Payments)]
        [PriorityTraits(Enums.TraitPriority.Low)]
        [ExpectedOutcomeTraits(Enums.TraitExpectedOutcome.Success)]
        [Theory]
        [InlineData(100.00, "Pagamento de R$100,00 processado via Cartão de Crédito.", typeof(CreditCardPaymentStrategy))]
        [InlineData(200.00, "Pagamento de R$200,00 processado via PayPal.", typeof(PayPalPaymentStrategy))]
        public void Test_PaymentStrategy_Success(decimal amount, string expected, Type strategyType)
        {
            // Arrange
            var strategy = (IPaymentStrategy)Activator.CreateInstance(strategyType);
            var paymentContext = new PaymentContext(strategy);

            // Act
            var result = paymentContext.ProcessOrderPayment(amount);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
