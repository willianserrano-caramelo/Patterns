using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.Interfaces;
using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.PaymentStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern
{
    public class PaymentContext
    {
        private IPaymentStrategy _paymentStrategy;

        public PaymentContext(IPaymentStrategy? paymentStrategy = null)
        {
            _paymentStrategy = paymentStrategy ?? new NullPaymentStrategy();
        }

        public string ProcessOrderPayment(decimal amount)
        {
            return _paymentStrategy.ProcessPayment(amount);
        }

        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy ?? new NullPaymentStrategy();
        }
    }
}
