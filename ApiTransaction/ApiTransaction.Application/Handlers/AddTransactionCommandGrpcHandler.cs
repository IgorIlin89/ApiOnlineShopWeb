using Transaction.Application.Commands;
using Transaction.Application.Interfaces;
using Transaction.Domain.Interfaces;

namespace Transaction.Application.Handlers;

public class AddTransactionCommandGrpcHandler(IUnitOfWork UnitOfWork,
    ITransactionRepository TransactionRepository) : IAddTransactionCommandGrpcHandler
{
    public Transaction.Domain.Transaction Handle(AddTransactionCommandGrpc command,
        CancellationToken cancellationToken)
    {
        var transactionToAdd = Transaction.Domain.Transaction.Create(
            command.UserId,
            command.ProductInCartList,
            command.couponsUsed
            );

        var result = TransactionRepository.Add(transactionToAdd, cancellationToken);
        return result;
    }

    Task<Domain.Transaction> IAddTransactionCommandGrpcHandler.Handle(AddTransactionCommandGrpc command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
