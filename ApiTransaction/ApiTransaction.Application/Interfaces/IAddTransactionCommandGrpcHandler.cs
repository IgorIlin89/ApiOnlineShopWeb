using Transaction.Application.Commands;

namespace Transaction.Application.Interfaces;

public interface IAddTransactionCommandGrpcHandler
{
    Task<Domain.Transaction> HandleAsync(AddTransactionCommand command, CancellationToken cancellationToken);
}