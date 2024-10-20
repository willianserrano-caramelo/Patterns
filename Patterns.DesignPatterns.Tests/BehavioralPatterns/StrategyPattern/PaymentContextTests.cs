using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern;
using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.PaymentStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.Tests.BehavioralPatterns.StrategyPattern
{
    public class PaymentContextTests
    {
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

        [Fact]
        public void Test_NullPaymentStrategy_DefaultBehavior()
        {
            // Arrange
            var paymentContext = new PaymentContext();

            // Act
            var result = paymentContext.ProcessOrderPayment(100.00m);

            // Assert
            Assert.Equal("Nenhuma estratégia de pagamento foi definida.", result);
        }

        [Fact]
        public void Test_SetNullPaymentStrategy_UsesNullStrategy()
        {
            // Arrange
            var paymentContext = new PaymentContext(new CreditCardPaymentStrategy());

            // Act
            paymentContext.SetPaymentStrategy(null);
            var result = paymentContext.ProcessOrderPayment(100.00m);

            // Assert
            Assert.Equal("Nenhuma estratégia de pagamento foi definida.", result);
        }
    }
}
