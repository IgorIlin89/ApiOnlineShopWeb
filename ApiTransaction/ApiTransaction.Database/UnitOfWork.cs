using Transaction.Domain.Interfaces;

namespace Transaction.Database;

public class UnitOfWork(TransactionContext DbContext) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
