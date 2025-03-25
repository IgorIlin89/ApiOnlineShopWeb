using Transaction.Application.Commands;
using Transaction.Application.Interfaces;
using Transaction.Domain.Interfaces;

namespace Transaction.Application.Handlers;

public class AddTransactionCommandHandler(IUnitOfWorkFactory UnitOfWorkFactory) : IAddTransactionCommandHandler
{
    public async Task<Domain.Transaction> HandleAsync(AddTransactionCommand command,
        CancellationToken cancellationToken)
    {
        var unitOfWork = UnitOfWorkFactory.Create();
        var transactionToAdd = Transaction.Domain.Transaction.Create(
            command.UserId,
            command.ProductInCartList,
            command.CouponsUsed
            );

        var result = await unitOfWork.TransactionRepository.AddAsync(transactionToAdd,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return result;
    }
}
