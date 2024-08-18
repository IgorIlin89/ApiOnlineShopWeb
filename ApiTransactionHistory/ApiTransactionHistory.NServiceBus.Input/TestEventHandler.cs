using NServiceBus;
using OnlineShopWeb.NServiceBus.Messages;

namespace ApiTransactionHistory.NServiceBus.Input;

public class TestEventHandler : IHandleMessages<TestEvent>
{
    public Task Handle(TestEvent message, IMessageHandlerContext context)
    {
        throw new NotImplementedException();
    }
}
