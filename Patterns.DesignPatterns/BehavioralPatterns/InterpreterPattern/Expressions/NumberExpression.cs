using Patterns.DesignPatterns.BehavioralPatterns.InterpreterPattern.Interfaces;
using Serilog;

namespace Patterns.DesignPatterns.BehavioralPatterns.InterpreterPattern.Expressions
{
    public class NumberExpression : IExpression
    {
        private readonly double _number;
        private readonly ILogger _logger;

        public NumberExpression(double number, ILogger logger)
        {
            _number = number;
            _logger = logger;
        }

        public double Interpret()
        {
            _logger.Information($"Interpreting number: {_number}");
            return _number;
        }
    }
}
