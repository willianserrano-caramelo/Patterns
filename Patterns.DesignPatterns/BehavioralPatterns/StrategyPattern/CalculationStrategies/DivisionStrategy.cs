using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.CalculationStrategies
{
    public class DivisionStrategy : ICalculationStrategy
    {
        public string Execute(int a, int b)
        {
            if (b == 0)
            {
                return "Erro: Divisão por zero!";
            }
            return $"Resultado da Divisão: {a / b}";
        }
    }
}
