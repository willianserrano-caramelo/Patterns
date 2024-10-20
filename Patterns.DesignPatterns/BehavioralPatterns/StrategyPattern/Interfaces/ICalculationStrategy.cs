using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.StrategyPattern.Interfaces
{
    public interface ICalculationStrategy
    {
        string Execute(int a, int b);
    }
}
