using ApiTransactionHistory.Application.Handlers;
using NServiceBus;
using OnlineShopWeb.NServiceBus.Messages;

namespace ApiTransactionHistory.NServiceBus.Input;

public class TestCommandHandler : IHandleMessages<TestCommand>
{
    public TestCommandHandler(IAddTransactionHistoryCommandHandler addTransactionHistoryCommandHandler)
    {

    }
    //This class creates command for example for AddTransctionHistory,
    //Than calls AddTransactionHistoryCommandHandler from Application
    public Task Handle(TestCommand message, IMessageHandlerContext context)
    {
        throw new NotImplementedException();
    }
}
