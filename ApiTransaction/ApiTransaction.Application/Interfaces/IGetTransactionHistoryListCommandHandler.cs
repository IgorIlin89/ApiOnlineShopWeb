using Transaction.Application.Commands;

namespace Transaction.Application.Interfaces;

public interface IGetTransactionListCommandHandler
{
    Task<List<Domain.Transaction>> HandleAsync(GetTransactionListCommand command,
        CancellationToken cancellationToken);
}