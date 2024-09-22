using Transaction.Application.Commands;
using Transaction.Application.Interfaces;
using Transaction.Domain.Interfaces;

namespace Transaction.Application.Handlers;

public class AddTransactionCommandHandler(IUnitOfWork UnitOfWork,
    ITransactionRepository TransactionRepository) : IAddTransactionCommandHandler
{
    public Domain.Transaction Handle(AddTransactionCommand command)
    {
        //command.TransactionToAdd.CalculateFinalPrice();

        var result = TransactionRepository.Add(command.TransactionToAdd);

        UnitOfWork.SaveChanges();

        return result;
    }
}
