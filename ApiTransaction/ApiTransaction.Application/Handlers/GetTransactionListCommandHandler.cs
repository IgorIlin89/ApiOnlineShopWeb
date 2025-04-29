using Transaction.Application.Commands;
using Transaction.Application.Interfaces;
using Transaction.Domain.Interfaces;


namespace Transaction.Application.Handlers;

public class GetTransactionListCommandHandler(IUnitOfWorkFactory UnitOfWorkFactory)
    : IGetTransactionListCommandHandler
{
    public async Task<List<Domain.Transaction>> HandleAsync(GetTransactionListCommand command,
        CancellationToken cancellationToken)
    {
        var unitOfWork = UnitOfWorkFactory.Create();
        var result = await unitOfWork.TransactionRepository.GetListAsync(command.Id,
            cancellationToken);
        return result;
    }
}
