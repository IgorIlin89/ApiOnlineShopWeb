using Transaction.Application.Commands;
using Transaction.Application.Interfaces;
using Transaction.Domain.Interfaces;


namespace Transaction.Application.Handlers;

public class GetTransactionListCommandHandler(ITransactionRepository TransactionRepository) : IGetTransactionListCommandHandler
{
    public List<Domain.Transaction> Handle(GetTransactionListCommand command)
    {
        var result = TransactionRepository.GetList(command.Id);
        return result;
    }
}
