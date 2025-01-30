using Transaction.Application.Commands;

namespace Transaction.Application.Interfaces;

public interface IGetTransactionListCommandHandler
{
    Task<List<Domain.Transaction>> Handle(GetTransactionListCommand command,
        CancellationToken cancellationToken);
}