using Grpc.Core;
using GrpcTestService.Contracts;
using Transaction.Application.Commands;
using Transaction.Application.Interfaces;

namespace Transaction.Service.Services;

public class AddTransactionService(IAddTransactionCommandGrpcHandler AddTransactionGrpcHandler)
    : GrpcTestService.Contracts.TransactionService.TransactionServiceBase
{
    public override async Task<GrpcTestService.Contracts.Transaction> AddTransactionRpc(
        AddTransaction request,
        ServerCallContext context)
    {
        var command = new AddTransactionCommand(
            request.UserId,
            request.ProductsInCart.MapToDomain(),
            request.Coupons.MapToDomain());

        var result = await AddTransactionGrpcHandler.HandleAsync(command, context.CancellationToken);

        return result.MapToGrpc();
    }
}
