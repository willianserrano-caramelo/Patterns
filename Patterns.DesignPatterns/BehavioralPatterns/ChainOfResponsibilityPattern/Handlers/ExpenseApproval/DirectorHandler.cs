using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Handlers.ExpenseApproval
{
    public class DirectorHandler : BaseHandler
    {
        public DirectorHandler(ILogger logger) : base(logger) { }

        public override void HandleRequest(object request)
        {
            if (request is decimal expenseAmount && expenseAmount > 10000)
            {
                _logger.LogInfo($"Diretor aprovou a despesa de R$ {expenseAmount}");
            } else
            {
                base.HandleRequest(request);
            }
        }
    }
}
