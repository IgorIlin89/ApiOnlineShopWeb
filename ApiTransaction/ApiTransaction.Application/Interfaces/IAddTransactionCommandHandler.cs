using Transaction.Application.Commands;

namespace Transaction.Application.Interfaces;

public interface IAddTransactionCommandHandler
{
    Task<Domain.Transaction> Handle(AddTransactionCommand command, CancellationToken cancellationToken);
}