using Transaction.Application.Commands;

namespace Transaction.Application.Interfaces;

public interface IAddTransactionCommandGrpcHandler
{
    Task<Domain.Transaction> Handle(AddTransactionCommand command, CancellationToken cancellationToken);
}