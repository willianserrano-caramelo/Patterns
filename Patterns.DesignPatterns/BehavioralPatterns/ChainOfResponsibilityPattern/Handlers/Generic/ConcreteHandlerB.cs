using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Handlers.Generic
{
    public class ConcreteHandlerB : BaseHandler
    {
        public ConcreteHandlerB(ILogger logger) : base(logger) { }

        public override void HandleRequest(object request)
        {
            if (request.ToString() == "B")
            {
                _logger.LogInfo("ConcreteHandlerB handled request: " + request);
            } else
            {
                base.HandleRequest(request);
            }
        }
    }
}
