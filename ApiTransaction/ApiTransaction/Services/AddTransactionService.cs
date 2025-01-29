using Grpc.Core;
using GrpcTestService.Contracts;
using Transaction.Application.Commands;
using Transaction.Application.Interfaces;

namespace Transaction.Service.Services;

public class AddTransactionService(IAddTransactionCommandGrpcHandler AddTransactionGrpcHandler)
    : GrpcTestService.Contracts.AddTransactionService.AddTransactionServiceBase
{
    public override async Task<GrpcTestService.Contracts.Transaction> AddTransactionRpc(AddTransaction request, ServerCallContext context)
    {
        var command = new AddTransactionCommandGrpc(
            request.Id,
            request.ProductsInCart.MapToDomain(),
            request.Coupons.MapToDomain());

        var result = await AddTransactionGrpcHandler.Handle(command, context.CancellationToken);

        //result = result.MapToGrpc();
        var response = new GrpcTestService.Contracts.Transaction
        {

        };

        return response;
    }
}
