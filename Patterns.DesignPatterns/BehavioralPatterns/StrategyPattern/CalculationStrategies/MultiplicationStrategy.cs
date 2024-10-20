using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.CalculationStrategies
{
    public class MultiplicationStrategy : ICalculationStrategy
    {
        public string Execute(int a, int b)
        {
            return $"Resultado da Multiplicação: {a * b}";
        }
    }
}
