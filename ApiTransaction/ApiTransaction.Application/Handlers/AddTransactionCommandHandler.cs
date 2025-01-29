using Transaction.Application.Commands;
using Transaction.Application.Interfaces;
using Transaction.Domain.Interfaces;

namespace Transaction.Application.Handlers;

public class AddTransactionCommandHandler(IUnitOfWork UnitOfWork,
    ITransactionRepository TransactionRepository) : IAddTransactionCommandHandler
{
    public Domain.Transaction Handle(AddTransactionCommand command,
        CancellationToken cancellationToken)
    {
        var result = TransactionRepository.Add(command.TransactionToAdd,
            cancellationToken);

        UnitOfWork.SaveChanges();

        return result;
    }
}
