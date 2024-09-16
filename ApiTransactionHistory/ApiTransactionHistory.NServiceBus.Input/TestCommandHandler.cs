//using NServiceBus;
//using OnlineShopWeb.NServiceBus.Messages;
//using Transaction.Application.Interfaces;

//namespace Transaction.NServiceBus.Input;

//public class TestCommandHandler : IHandleMessages<TestCommand>
//{
//    public TestCommandHandler(IAddTransactionCommandHandler addTransactionCommandHandler)
//    {

//    }
//    //This class creates command for example for AddTransctionHistory,
//    //Than calls AddTransactionCommandHandler from Application
//    public Task Handle(TestCommand message, IMessageHandlerContext context)
//    {
//        throw new NotImplementedException();
//    }
//}
