using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.PaymentStrategies
{
    public class NullPaymentStrategy : IPaymentStrategy
    {
        public string ProcessPayment(decimal amount)
        {
            return "Nenhuma estratégia de pagamento foi definida.";
        }
    }
}
