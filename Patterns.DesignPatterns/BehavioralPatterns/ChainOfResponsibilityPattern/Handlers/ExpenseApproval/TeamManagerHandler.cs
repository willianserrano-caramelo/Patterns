using Serilog;

namespace Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Handlers.ExpenseApproval
{
    public class TeamManagerHandler : BaseHandler
    {
        public TeamManagerHandler(ILogger logger) : base(logger) { }

        public override void HandleRequest(object request)
        {
            if (request is decimal expenseAmount && expenseAmount <= 1000)
            {
                _logger.Information($"Gerente de Equipe aprovou a despesa de R$ {expenseAmount}");
            } else
            {
                base.HandleRequest(request);
            }
        }
    }
}
