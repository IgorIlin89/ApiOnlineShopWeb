using Transaction.Application.Commands;
using Transaction.Application.Interfaces;
using Transaction.Domain.Interfaces;


namespace Transaction.Application.Handlers;

public class GetTransactionListCommandHandler(ITransactionRepository TransactionRepository)
    : IGetTransactionListCommandHandler
{
    public async Task<List<Domain.Transaction>> Handle(GetTransactionListCommand command,
        CancellationToken cancellationToken)
    {
        var result = await TransactionRepository.GetListAsync(command.Id,
            cancellationToken);
        return result;
    }
}
