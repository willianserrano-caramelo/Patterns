using Patterns.DesignPatterns.BehavioralPatterns.InterpreterPattern.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.InterpreterPattern.Expressions
{
    public class DivideExpression : IExpression
    {
        private readonly IExpression _leftExpression;
        private readonly IExpression _rightExpression;
        private readonly ILogger _logger;

        public DivideExpression(IExpression leftExpression, IExpression rightExpression, ILogger logger)
        {
            _leftExpression = leftExpression;
            _rightExpression = rightExpression;
            _logger = logger;
        }

        public double Interpret()
        {
            double left = _leftExpression.Interpret();
            double right = _rightExpression.Interpret();

            if (right == 0)
            {
                _logger.Error("Attempted to divide by zero.");
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            _logger.Information($"Dividing {left} / {right}");
            return left / right;
        }
    }
}
