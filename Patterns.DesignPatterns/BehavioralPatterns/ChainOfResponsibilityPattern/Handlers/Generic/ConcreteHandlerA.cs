using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Handlers.Generic
{
    public class ConcreteHandlerA : BaseHandler
    {
        public ConcreteHandlerA(ILogger logger) : base(logger) { }

        public override void HandleRequest(object request)
        {
            if (request.ToString() == "A")
            {
                _logger.LogInfo("ConcreteHandlerA handled request: " + request);
            } else
            {
                base.HandleRequest(request);
            }
        }
    }
}
