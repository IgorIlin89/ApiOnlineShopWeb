using Transaction.Domain.Interfaces;

namespace Transaction.Database;

public class UnitOfWork : IUnitOfWork
{
    public ITransactionRepository TransactionRepository { get; init; }
    private readonly TransactionContext _dbContext;
    public UnitOfWork(TransactionContext dbContext)
    {
        _dbContext = dbContext;
        TransactionRepository = new TransactionRepository(dbContext);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
