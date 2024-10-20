using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern
{
    public abstract class StrategyContextBase
    {
        protected ICalculationStrategy _strategy;

        protected StrategyContextBase(ICalculationStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy), "Estratégia não pode ser nula");
        }

        public void SetStrategy(ICalculationStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy), "Estratégia não pode ser nula");
        }
    }
}
