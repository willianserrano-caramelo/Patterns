using Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Interfaces;
using Serilog;

namespace Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Handlers
{
    public abstract class BaseHandler : IHandler
    {
        private IHandler _nextHandler;
        protected readonly ILogger _logger;

        public BaseHandler(ILogger logger)
        {
            _logger = logger;
        }

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual void HandleRequest(object request)
        {
            if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            } else
            {
                _logger.Information("Nenhum manipulador disponível para esta solicitação.");
            }
        }
    }

}
