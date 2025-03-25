using NServiceBus;
using OnlineShopWeb.Messages.V2.Events;
using Transaction.Application.Commands;
using Transaction.Application.Interfaces;
using Transaction.Domain;
using Transaction.NServiceBus.Input.V2.Mapping;

namespace Transaction.NServiceBus.Input.V2.Events;


public class AddTransactionHandler(IAddTransactionCommandHandler transactionCommandHandler)
    : IHandleMessages<AddTransactionEvent>
{
    public async Task Handle(AddTransactionEvent message, IMessageHandlerContext context)
    {
        var addProductsInCartList = message.AddProductsInCartDto.MapToDomain();
        var addCouponsUsed = new List<Coupon>();

        if (message.AddCouponsDto.Count != 0)
        {
            var addCouponsDto = message.AddCouponsDto.MapToDomain();
        }

        var command = new AddTransactionCommand(message.UserId, addProductsInCartList, addCouponsUsed);
        var result = transactionCommandHandler.HandleAsync(command, context.CancellationToken);
    }
}