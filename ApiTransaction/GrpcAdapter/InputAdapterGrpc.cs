using Grpc.Core;

namespace GrpcAdapter;

public class InputAdapterGrpc
{
    //using GRPC contracts
    //public AddTransactionService
    public override async Task<Transaction.Domain.Transaction> AddTransactionRpc(
        AddTransaction request, ServerCallContext context)
    {
        //handler call

        return new Transaction.Domain.Transaction
    }
}
