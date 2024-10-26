using Patterns.DesignPatterns.BehavioralPatterns.InterpreterPattern.Interfaces;
using Serilog;

namespace Patterns.DesignPatterns.BehavioralPatterns.InterpreterPattern.Expressions
{
    public class MultiplyExpression : IExpression
    {
        private readonly IExpression _leftExpression;
        private readonly IExpression _rightExpression;
        private readonly ILogger _logger;

        public MultiplyExpression(IExpression leftExpression, IExpression rightExpression, ILogger logger)
        {
            _leftExpression = leftExpression;
            _rightExpression = rightExpression;
            _logger = logger;
        }

        public double Interpret()
        {
            double left = _leftExpression.Interpret();
            double right = _rightExpression.Interpret();
            _logger.Information($"Multiplying {left} * {right}");
            return left * right;
        }
    }
}
