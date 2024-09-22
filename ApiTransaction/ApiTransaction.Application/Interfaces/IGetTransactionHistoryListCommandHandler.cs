using Transaction.Application.Commands;

namespace Transaction.Application.Interfaces;

public interface IGetTransactionListCommandHandler
{
    List<Domain.Transaction> Handle(GetTransactionListCommand command);
}