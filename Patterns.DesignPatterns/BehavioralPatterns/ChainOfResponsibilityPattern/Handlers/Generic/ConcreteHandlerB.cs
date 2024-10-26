using Serilog;

namespace Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Handlers.Generic
{
    public class ConcreteHandlerB : BaseHandler
    {
        public ConcreteHandlerB(ILogger logger) : base(logger) { }

        public override void HandleRequest(object request)
        {
            if (request.ToString() == "B")
            {
                _logger.Information("ConcreteHandlerB handled request: " + request);
            } else
            {
                base.HandleRequest(request);
            }
        }
    }
}
