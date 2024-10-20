using Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.CalculationStrategies
{
    public class SubtractionStrategy : ICalculationStrategy
    {
        public string Execute(int a, int b)
        {
            if (a < 0 || b < 0)
            {
                return "Erro: Números negativos não são permitidos!";
            }
            return $"Resultado da Subtração: {a - b}";
        }
    }
}
