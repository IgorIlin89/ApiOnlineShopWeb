using NServiceBus;
using OnlineShopWeb.Messages.V1.Events;
using Transaction.Application.Commands;
using Transaction.Application.Interfaces;
using Transaction.Domain;
using Transaction.NServiceBus.Input.V1.Mapping;

namespace Transaction.NServiceBus.Input.V1.Events;

public class AddTransactionHandler(IAddTransactionCommandHandler transactionCommandHandler
    ) : IHandleMessages<AddTransactionEvent>
{
    public async Task Handle(AddTransactionEvent message, IMessageHandlerContext context)
    {
        var addProductsInCartList = message.AddProductsInCartDto.MapToProductInCartList();
        var addCouponsUsed = new List<TransactionToCoupons>();

        if (message.AddCouponsDto is not null)
        {
            var addCouponsDto = message.AddCouponsDto.MapToTransactionToCouponsList();
        }

        var command = new AddTransactionCommand(message.UserId, addProductsInCartList, addCouponsUsed);
        var result = transactionCommandHandler.Handle(command, context.CancellationToken);

        //logger.Information($"Transaction with the id {result.Id} has been completed");
    }
}
