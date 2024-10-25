using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Handlers.ExpenseApproval
{
    public class TeamManagerHandler : BaseHandler
    {
        public TeamManagerHandler(ILogger logger) : base(logger) { }

        public override void HandleRequest(object request)
        {
            if (request is decimal expenseAmount && expenseAmount <= 1000)
            {
                _logger.LogInfo($"Gerente de Equipe aprovou a despesa de R$ {expenseAmount}");
            } else
            {
                base.HandleRequest(request);
            }
        }
    }
}
