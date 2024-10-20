using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.PaymentStrategies
{
    public class PayPalPaymentStrategy : IPaymentStrategy
    {
        public string ProcessPayment(decimal amount)
        {
            return $"Pagamento de R${amount} processado via PayPal.";
        }
    }
}
