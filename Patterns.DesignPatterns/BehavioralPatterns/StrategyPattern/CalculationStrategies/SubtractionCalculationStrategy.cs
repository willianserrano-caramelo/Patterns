using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.Interfaces;
using Patterns.DesignPatterns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.CalculationStrategies
{
    public class SubtractionCalculationStrategy : ICalculationStrategy
    {
        public string Execute(int a, int b)
        {
            if (a < 0 || b < 0)
            {
                throw new NegativeNumberException();
            }
            return $"Resultado da Subtração: {a - b}";
        }
    }
}
