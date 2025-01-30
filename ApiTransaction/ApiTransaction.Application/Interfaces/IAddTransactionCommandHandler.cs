using Transaction.Application.Commands;

namespace Transaction.Application.Interfaces;

public interface IAddTransactionCommandHandler
{
    Task<Domain.Transaction> HandleAsync(AddTransactionCommand command, CancellationToken cancellationToken);
}