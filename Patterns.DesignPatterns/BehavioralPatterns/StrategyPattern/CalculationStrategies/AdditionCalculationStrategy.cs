using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.CalculationStrategies
{
    public class AdditionCalculationStrategy : ICalculationStrategy
    {
        public string Execute(int a, int b)
        {
            return $"Resultado da Adição: {a + b}";
        }
    }
}
