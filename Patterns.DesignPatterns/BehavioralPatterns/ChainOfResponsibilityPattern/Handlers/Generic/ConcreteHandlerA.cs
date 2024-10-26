using Serilog;

namespace Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Handlers.Generic
{
    public class ConcreteHandlerA : BaseHandler
    {
        public ConcreteHandlerA(ILogger logger) : base(logger) { }

        public override void HandleRequest(object request)
        {
            if (request.ToString() == "A")
            {
                _logger.Information("ConcreteHandlerA handled request: " + request);
            } else
            {
                base.HandleRequest(request);
            }
        }
    }
}
