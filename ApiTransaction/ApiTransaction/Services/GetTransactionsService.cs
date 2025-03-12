using Grpc.Core;
using GrpcTestService.Contracts;
using Transaction.Application.Commands;
using Transaction.Application.Interfaces;

namespace Transaction.Service.Services;

public class GetTransactionsService(IGetTransactionListCommandHandler TransactionListCommandHandler)
    : GrpcTestService.Contracts.TransactionService.TransactionServiceBase
{
    public override async Task<TransactionList> GetTransactionsRpc(
        GetTransactions request,
        ServerCallContext context)
    {
        var command = new GetTransactionListCommand(Int32.Parse(request.UserId));
        var result = await TransactionListCommandHandler.HandleAsync(command, context.CancellationToken);
        return result.MapToGrpcList();
    }
}
