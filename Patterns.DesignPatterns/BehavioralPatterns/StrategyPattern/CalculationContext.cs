using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern
{
    public class CalculationContext : StrategyContextBase
    {
        public CalculationContext(ICalculationStrategy strategy) : base(strategy)
        {
        }

        public string ExecuteStrategy(int a, int b)
        {
            return _strategy.Execute(a, b);
        }
    }
}
