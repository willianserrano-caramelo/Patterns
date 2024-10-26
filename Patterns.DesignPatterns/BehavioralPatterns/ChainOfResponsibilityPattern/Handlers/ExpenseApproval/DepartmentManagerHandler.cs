using Serilog;

namespace Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Handlers.ExpenseApproval
{
    public class DepartmentManagerHandler : BaseHandler
    {
        public DepartmentManagerHandler(ILogger logger) : base(logger) { }

        public override void HandleRequest(object request)
        {
            if (request is decimal expenseAmount && expenseAmount > 1000 && expenseAmount <= 10000)
            {
                _logger.Information($"Gerente de Departamento aprovou a despesa de R$ {expenseAmount}");
            } else
            {
                base.HandleRequest(request);
            }
        }
    }
}
