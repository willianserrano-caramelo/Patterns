using Logger.Interfaces;
using Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Handlers.ExpenseApproval;
using Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern.Handlers.Generic;

namespace Patterns.DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern
{
    public class Client
    {
        private readonly ILogger _logger;

        // O ILogger é injetado no Client, e passado para os Handlers
        public Client(ILogger logger)
        {
            _logger = logger;
        }

        // Método para o exemplo genérico do Chain of Responsibility
        public void ExecuteGenericExample()
        {
            var handlerA = new ConcreteHandlerA(_logger);
            var handlerB = new ConcreteHandlerB(_logger);

            handlerA.SetNext(handlerB);

            _logger.LogInfo("Sending request 'A'");
            handlerA.HandleRequest("A");

            _logger.LogInfo("Sending request 'B'");
            handlerA.HandleRequest("B");

            _logger.LogInfo("Sending request 'C'");
            handlerA.HandleRequest("C");
        }

        // Método para o exemplo de negócio: Aprovação de Despesas
        public void ExecuteExpenseApprovalExample()
        {
            var teamManager = new TeamManagerHandler(_logger);
            var departmentManager = new DepartmentManagerHandler(_logger);
            var director = new DirectorHandler(_logger);

            teamManager.SetNext(departmentManager).SetNext(director);

            _logger.LogInfo("Enviando pedido de despesa de R$ 500");
            teamManager.HandleRequest(500m);

            _logger.LogInfo("Enviando pedido de despesa de R$ 5.000");
            teamManager.HandleRequest(5000m);

            _logger.LogInfo("Enviando pedido de despesa de R$ 50.000");
            teamManager.HandleRequest(50000m);
        }
    }

}
